app.factory("AuthService", function ($http, $q) {
	var authService = {
		login: login,
		register: register
	};

	return authService;

	function login(userInfo) {
		var deferred = $q.defer();
		$http.post("/api/account/login", userInfo).success(function (response) {
					deferred.resolve(response);
				}).error(function (error) {
					deferred.reject(error);
				});
		return deferred.promise;
	}

	function register(userInfo) {
		var deferred = $q.defer();
		$http.post("/api/account/register", userInfo).success(function (response) {
			deferred.resolve(response);
		}).error(function (error) {
			deferred.reject(error);
		});
		return deferred.promise;
	}

	function search(searchInfo) {
	    var deferred = $q.defer();
	    $http.post("/api/account/search", searchInfo).success(function (response) {
	        deferred.resolve(response);
	    }).error(function (error) {
	        deferred.reject(error);
	    });
	    return deferred.promise;
	}
});