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