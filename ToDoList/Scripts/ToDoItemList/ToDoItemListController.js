app.controller('ToDoItemListController', ["$scope", "$location", "ToDoItemService",
	function ($scope, $location, toDoItemService) {
		$scope.reset = function () {
			$scope.items = toDoItemService.query();
		};

		$scope.reset();
		
	}
]);