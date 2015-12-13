var app = angular.module("ToDoApp", ["ngResource", "ngRoute", 'ui.bootstrap', 'LocalStorageModule'])
	.config(function ($routeProvider) {

		$routeProvider.when('/toDoItems', {
			controller: 'ToDoItemListController',
			templateUrl: 'Scripts/ToDoItemList/toDoItemList.html'
		})
			.when('/new', {
				controller: 'CreateCtrl',
				templateUrl: 'detail.html'
			})
            .when('/edit/:itemId', {
            	controller: EditCtrl,
            	templateUrl: 'detail.html'
            })
			.when('/', {
				controller: "LoginController",
				templateUrl: "Scripts/Auth/LoginPage.html"
			})
			.otherwise({
				redirectTo: '/'
			});
	});

var CreateCtrl = function ($scope, $location, $modalInstance, ToDoItemService, localStorageService) {
    $scope.btnName = "Add";

    $scope.close = function () {
    	$modalInstance.close();
    }

    $scope.save = function () {
    	$scope.item.userId = localStorageService.get("userInfo").userId;
    	ToDoItemService.newItem($scope.item).then(function (response) {
    		$location.path("/toDoItems");
    		$modalInstance.close();
    	});
    };
};

app.controller("CreateCtrl", CreateCtrl);

var EditCtrl = function ($scope, $routeParams, $location, ToDoItemService) {
	ToDoItemService.getItem($routeParams.itemId).then(function (response) {
		$scope.item = response;
	});
    $scope.btnName = "Edit";

    $scope.save = function () {
        ToDoItemService.editItem($scope.item).then(function (response) {
            $location.path('/toDoItems');
        });
    };
};

