app.controller("RegisterController", ["$scope", "$modalInstance", "$location", "AuthService", "localStorageService",
	function ($scope, $modalInstance, $location, AuthService, localStorageService) {
		$scope.closeModal = function () {
			$modalInstance.close();
			$location.path("/");
		}

		$scope.register = function () {
			if ($scope.registerForm.$valid) {
				if ($scope.password === $scope.repeatPassword) {
					AuthService.register({
						firstName: $scope.firstName,
						lastName: $scope.lastName,
						userName: $scope.userName,
						password: $scope.password
					}).then(function (response) {
						localStorageService.set("userInfo", {
							userName: $scope.userName
						});
						$location.path("/toDoItems");
					}, function (error) {
						$scope.errorMessage = angular.fromJson(error).message;
					});
				}
				else {
					$scope.errorMessage = "password doesn't match repeated password";
				}
				
			}
		}
	}
]);