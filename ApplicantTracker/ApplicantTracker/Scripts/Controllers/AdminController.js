(function (angular) {


    angular.module('sbAdminApp').controller('AdminController',
       ['$scope', '$modal', '$log', function ($scope, $modal, $log) {

              $scope.User = {};
              $scope.User.UserId = '';
              $scope.User.FirstName= '';
              $scope.User.LastName= '';  
              $scope.User.MiddleName= '';  
              $scope.User.Password= '';   
              $scope.User.Details= '';
              $scope.User.DOB= '';  
              $scope.User.Address= ''; 
              $scope.User.MaritalStatus= '';  
              $scope.User.Gender = ''; 
              $scope.User.Mobile= '';  
              $scope.User.Email= '';  
              $scope.User.IsActive = '';

              $scope.open = function (size) {
               debugger;
               var modalInstance = $modal.open({
                   size: size,
                   animation: false,
                   backdrop: 'static',
                   templateUrl: '/Templates/Administration/CreateUser.html',
                   controller: 'createUserModalCtrl',
                   // scope: $scope,
                   resolve: {
                       user: function () {
                           return $scope.user;
                       }
                   }
               });
               modalInstance.result.then(function (response) {
                   debugger;
                   $scope.currentUser = response;
               }, function () {
                   $log.info('Modal dismissed at: ' + new Date());
               });
           };



       }]);


    angular.module('sbAdminApp').controller('createUserModalCtrl',
       ['$scope', '$modalInstance', 'user', function ($scope, $modalInstance, user) {


           $scope.SaveUser = function () {


           };
       }]);
           
}(angular));
