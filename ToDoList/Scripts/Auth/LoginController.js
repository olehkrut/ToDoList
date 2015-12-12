app.controller("LoginController", ["$scope", "$location", "$modal", "AuthService",
	function ($scope, $location, $modal, AuthService) {
		$scope.login = function () {
			if ($scope.loginForm.$valid) {
				AuthService.login({
					userName: $scope.userName,
					password: $scope.password
				}).then(function (ok) {

				}, function (error) {

				});
			}
		}
}]);