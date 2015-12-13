app.controller('ToDoItemListController', ["$scope", "$location", "ToDoItemService", "localStorageService", "$modal",
	function ($scope, $location, toDoItemService, localStorageService, $modal) {
		toDoItemService.getAllItems(localStorageService.get("userInfo").userId).then(function (response) {
			$scope.items = response;
		}, function (error) {
			console.log(error);
		});
		
		$scope.isAuthorize = function () {
		var userInfo = localStorageService.get("userInfo");
		if (userInfo) {
			//$location.path("/toDoItems");
			return true;
		}
		else {
			$location.path("/");
		}
	}

	$scope.signOut = function () {
		localStorageService.set("userInfo", null);

	}

		$scope.newItem = function () {
			$modal.open({
				animation: true,
				controller: 'CreateCtrl',
				templateUrl: 'detail.html',
				size: 'sm'
			});
		}
	}
]);