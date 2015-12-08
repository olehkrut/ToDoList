app.factory("ToDoItemService", [ "$resource",
	function($resource) {
		var toDoItemService = {
			getAllItems: getAllItems
		}

		return $resource('/api/toDoItem/:id', { id: '@id' }, { update: { method: 'PUT' } });

		function getAllItems() {
			var deffered = $q.defer();
			$http.get('/api/ToDoItem').success(function(response) {
				deffered.resolve(response);
			}).error(function(error) {
				deffered.reject(error);
			});

			return deffered.promise;
		}

		function getItemsByQuery(query) {
			var deffered = $q.defer();
		}

	}
]);