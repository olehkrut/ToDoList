app.controller("LoginController", ["$scope", "$location", "$modal", "AuthService", "localStorageService",
	function ($scope, $location, $modal, AuthService, localStorageService) {
		$scope.login = function () {
			if ($scope.loginForm.$valid) {
				AuthService.login({
					userName: $scope.userName,
					password: $scope.password
				}).then(function (ok) {
					localStorageService.set("userInfo", {
						userName: $scope.userName,
						userId: ok
					});
					$location.path("/toDoItems");
				}, function (error) {
					$scope.errorMessage = angular.fromJson(error).message;
				});
			}
		}

		$scope.register = function () {
			var modal = $modal.open({
				animation: true,
				templateUrl: "Scripts/Auth/RegisterModal.html",
				controller: "RegisterController",
				size: "md"
			})
		}
}]);