var app = angular.module("ToDoApp", ["ngResource", "ngRoute", 'ui.bootstrap', 'LocalStorageModule'])
	.config(function ($routeProvider) {

		$routeProvider.when('/toDoItems', {
			controller: 'ToDoItemListController',
			templateUrl: 'Scripts/ToDoItemList/toDoItemList.html'
		})
			.when('/new', { controller: CreateCtrl, templateUrl: 'detail.html' })
            .when('/edit/:itemId', { controller: EditCtrl, templateUrl: 'detail.html' })
			.when('/', {
				controller: "LoginController",
				templateUrl: "Scripts/Auth/LoginPage.html"
			})
			.otherwise({
				redirectTo: '/'
			});
	});

var CreateCtrl = function ($scope, $location, Todo) {
    $scope.btnName = "Add";

    $scope.save = function () {
        Todo.save($scope.item, function () {
            $location.path('/');
        });
    };
};

var EditCtrl = function ($scope, $routeParams, $location, Todo) {
    $scope.item = Todo.get({ id: $routeParams.itemId });
    $scope.btnName = "Edit";

    $scope.save = function () {
        Todo.update({ id: $scope.item.TodoItemId }, $scope.item, function () {
            $location.path('/');
        });
    };
};

app.controller("IndexController", function ($scope, $location, localStorageService) {
	$scope.isAuthorize = function () {
		var userInfo = localStorageService.get("userInfo");
		if (userInfo) {
			$location.path("/toDoItems");
			return true;
		}
		else {
			$location.path("/");
		}
	}

	$scope.signOut = function () {
		localStorageService.set("userInfo", null);

	}
})