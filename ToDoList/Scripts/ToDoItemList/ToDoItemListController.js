app.controller('ToDoItemListController', ["$scope", "$location", "ToDoItemService",
	function ($scope, $location, toDoItemService) {

		toDoItemService.getAllItems().then(function(response) {
			$scope.item = response;
		}, function(error) {
			console.log(error);
		});
	}
]);