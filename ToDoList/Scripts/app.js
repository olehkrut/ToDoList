var app = angular.module("ToDoApp", ["ngResource", "ngRoute"])
	.config(function ($routeProvider) {

		$routeProvider.when('/', {
			controller: 'ToDoItemListController',
			templateUrl: 'Scripts/ToDoItemList/toDoItemList.html'
		})
			.when('/new', {
				controller: 'CreateNewItemController',
				templateUrl: 'detail.html'
			})
			.otherwise({
				redirectTo: '/'
			});
	});