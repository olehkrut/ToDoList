app.controller("RegisterController", ["$scope", "$modalInstance", "$location", "AuthService",
	function ($scope, $modalInstance, $location, AuthService) {
		$scope.closeModal = function () {
			$modalInstance.close();
		}

		$scope.register = function () {
			if ($scope.registerForm.$valid) {
				if ($scope.password === $scope.repearPassword) {
					AuthService.register({
						firstName: $scope.firstName,
						lastName: $scope.lastName,
						userName: $scope.userName,
						password: $scope.password
					}).then(function (response) {
						$location.path("/toDoItems");
					}, function (error) {
						$scope.errorMessage = error;
					});
				}
				else {
					$scope.errorMessage = "password doesn't match repeated password";
				}
				
			}
		}
	}
]);