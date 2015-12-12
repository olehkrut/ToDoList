app.controller("RegisterController", ["$scope", "$modalInstance", "$location", "AuthService",
	function ($scope, $modalInstance, $location, AuthService) {
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