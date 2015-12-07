var app = angular.module("ToDoApp", ["ngResource", "ngRoute"])
	.config(function($routeProvider) {

		$routeProvider.when('/', {
				controller: 'ToDoItemListController',
				templateUrl: 'Views/toDoItemList.html'
			})
			.otherwise({
				redirectTo: '/'
			});
	});