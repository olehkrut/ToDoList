app.factory("ToDoItemService", [ "$resource", "$q", "$http",
	function($resource, $q, $http) {
		var toDoItemService = {
			getAllItems: getAllItems,
			getItem: getItem,
			editItem: editItem,
			newItem: newItem
		}

		return toDoItemService;

		function getAllItems(userId) {
			var deferred = $q.defer();
			$http.get('/api/toDoItem?userId=' + userId).success(function(response) {
				deferred.resolve(response);
			}).error(function(error) {
				deferred.reject(error);
			});
			return deferred.promise;
		}

		function editItem(item) {
			var deferred = $q.defer();
			$http.post('/api/toDoItem/edit', item).success(function (response) {
				deferred.resolve(response);
			}).error(function (error) {
				deferred.reject(error);
			});
			return deferred.promise;
		}

		function getItem(itemId) {
			var deferred = $q.defer();
			$http.get('/api/toDoItem?itemId=' + itemId).success(function (response) {
				deferred.resolve(response);
			}).error(function (error) {
				deferred.reject(error);
			});
			return deferred.promise;
		}

		function newItem(newItem) {
			var deferred = $q.defer();
			$http.post('/api/toDoItem/createItem', newItem).success(function (response) {
				deferred.resolve(response);
			}).error(function (error) {
				deferred.reject(error);
			});
			return deferred.promise;
		}

	}
]);