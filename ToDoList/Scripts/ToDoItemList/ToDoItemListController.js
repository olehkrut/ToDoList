app.controller('ToDoItemListController', ["$scope", "$location", "ToDoItemService",
	function ($scope, $location, toDoItemService) {

		toDoItemService.getAllItems().then(function(response) {
			$scope.items = response;
		}, function(error) {
			console.log(error);
		});
	}
]);