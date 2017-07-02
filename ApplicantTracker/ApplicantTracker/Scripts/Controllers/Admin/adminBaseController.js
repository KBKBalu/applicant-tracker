(function (angular) {
    angular.module('sbAdminApp').controller('adminBaseController',
        ['$scope', '$modal', function ($scope, $modal) {
            debugger;
            $scope.items = [
                {
                    Name: 'Roles',
                    Id: 0
                },

     {
         Name: 'Status',
         Id: 1
     }, {
         Name: 'Company',
         Id: 2
     },
      {
          Name: 'Industry',
          Id: 3
      }
            ];
        }]);
       
})
(angular);