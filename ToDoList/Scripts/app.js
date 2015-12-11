var app = angular.module("ToDoApp", ["ngResource", "ngRoute"])
	.config(function ($routeProvider) {

		$routeProvider.when('/ToDoItems', {
			controller: 'ToDoItemListController',
			templateUrl: 'Scripts/ToDoItemList/toDoItemList.html'
		})
			.when('/new', {
				controller: 'CreateNewItemController',
				templateUrl: 'Scripts/NewItem/detail.html'
			})
			.when('/', {
				controller: "LoginController",
				templateUrl: "Views/LoginPage.html"
			})
			.otherwise({
				redirectTo: '/'
			});
	});