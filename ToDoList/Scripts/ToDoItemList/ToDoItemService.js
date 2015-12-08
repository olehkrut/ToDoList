app.factory("ToDoItemService", [
	"$http", "$q",
	function($http, $q) {
		var toDoItemService = {
			getAllItems: getAllItems
		}

		return toDoItemService;

		function getAllItems() {
			var deffered = $q.defer();
			$http.get('/api/ToDoItem').success(function(response) {
				deffered.resolve(response);
			}).error(function(error) {
				deffered.reject(error);
			});

			return deffered.promise;
		}

	}
]);