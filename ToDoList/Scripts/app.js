var app = angular.module("ToDoApp", ["ngResource", "ngRoute", 'ui.bootstrap', 'LocalStorageModule'])
	.config(function ($routeProvider) {

		$routeProvider.when('/toDoItems', {
			controller: 'ToDoItemListController',
			templateUrl: 'Scripts/ToDoItemList/toDoItemList.html'
		})
			.when('/new', {
				controller: 'CreateNewItemController',
				templateUrl: 'Scripts/NewItem/detail.html'
			})
			.when('/', {
				controller: "LoginController",
				templateUrl: "Scripts/Auth/LoginPage.html"
			})
			.otherwise({
				redirectTo: '/'
			});
	});

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