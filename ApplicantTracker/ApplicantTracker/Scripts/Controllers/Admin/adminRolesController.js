(function (angular) {
    angular.module('sbAdminApp').controller('adminRolesController',
        ['$scope', '$modal', 'userService', 'fieldsLengthRestrictions', function ($scope, $modal, userService, fieldsLengthRestrictions) {
            debugger;

            $scope.items = {};

            $scope.statusCreate = {};
            $scope.statusCreate.CanStatusId = '';
            $scope.statusCreate.Name = '';
            $scope.statusCreate.Description = '';
            $scope.statusCreate.IsActive = '';



            $scope.ConfirmationMessage = "Role Created Successfully."
            $scope.ErrorMessage = "Failed.";
            $scope.SuccessMessage = "Sucess";
            $scope.IsError = false;
            $scope.IsConfirmed = false;

            $scope.ConfirmationUrl = '/Templates/Common/Confirmation.html';
            $scope.ErrorUrl = '/Templates/Common/Error.html';
            $scope.SuccessUrl = '/Templates/Common/Success.html'

            userService.getAllRoles()
                       .success(function (data) {
                           debugger;
                           //alert(data);
                           $scope.items = data;
                           // $scope.isLoading = false;                            

                       })
                       .error(function (data) {
                           debugger;
                           //$scope.isLoading = false;
                           console.log('Error: ', data)
                       });

            $scope.open = function (size) {
                debugger;
                var modalInstance = $modal.open({
                    size: '100px',
                    animation: false,
                    backdrop: 'static',
                    templateUrl: '/Templates/Admin/admin-create-list.html',
                    controller: 'roleCreateCtrl',
                    scope: $scope,
                    windowClass: 'large-Modal',
                    resolve: {
                        statusCreate: function () {
                            return $scope.statusCreate;
                        }
                    }
                });
                modalInstance.result.then(function (response) {
                    debugger;
                }, function () {
                    $log.info('Modal dismissed at: ' + new Date());
                });
            };

            $scope.createEdit = function (role, flag) {

                userService.getAllRoles()
                   .success(function (data) {

                       debugger;
                       $scope.items = data;
                       $scope.statusEdit = {};
                       $scope.statusEdit.CanStatusId = role.RoleId;

                       angular.forEach($scope.items, function (value, key) {
                           debugger;

                           if (value.RoleId == $scope.statusEdit.CanStatusId) {
                              
                               $scope.statusEdit.RoleId = value.RoleId;
                               $scope.statusEdit.Name = value.Name;
                               $scope.statusEdit.Description = value.Description;
                               $scope.statusEdit.IsActive = value.IsActive;
                           }

                       });

                       debugger;
                       var modalInstance = $modal.open({
                           size: '500px',
                           animation: false,
                           backdrop: 'static',
                           templateUrl: '/Templates/Admin/admin-edit-list.html',
                           controller: 'adminRoleEditCtrl',
                           scope: $scope,
                           windowClass: 'large-Modal',
                           resolve: {
                               adminEdit: function () {
                                   return $scope.adminEdit;
                               }
                           }
                       });
                       modalInstance.result.then(function (response) {
                           debugger;
                       }, function () {
                           $log.info('Modal dismissed at: ' + new Date());
                       });


                   })
                   .error(function (data) {
                       debugger;
                       //$scope.isLoading = false;
                       console.log('Error: ', data)
                   });


            };

            $scope.deleteItem = function (role, flag) {
                debugger;

                if (!flag) {
                    if (role.IsActive != false) {
                        role.IsActive = false;
                        userService.disableRole(role).success(
                            function (data) {
                                $scope.showAlert($scope.SuccessUrl);
                            });
                    }
                    else {

                        $scope.showAlert($scope.ErrorUrl);

                    }
                }

                $modalInstance.dismiss('cancel');
            };

            $scope.showAlert = function (url) {
                debugger;

                //var url = '/Templates/Common/' + $scope.FileName;
                debugger;
                var modalInstance = $modal.open({
                    animation: false,
                    backdrop: 'static',
                    templateUrl: url,
                    controller: 'AlterModalController',
                    keyboard: false,
                    scope: $scope,
                    windowclass: 'centre-Modal',
                    resolve: {
                        param1: null
                    }
                });
                modalInstance.result.then(function (response) {


                }, function () {
                });
            };
        }]);


    angular.module('sbAdminApp').controller('adminRoleEditCtrl',
['$scope', '$modalInstance', 'userService', 'fieldsLengthRestrictions', function ($scope, $modalInstance, userService, fieldsLengthRestrictions) {

    $scope.restrictions = fieldsLengthRestrictions.validator.pattern;
    $scope.errorMessage = fieldsLengthRestrictions.validator.errormessage;

    $scope.Update = function () {
        debugger;
        var model = $scope.statusEdit;
        userService.UpdateRole(model).success(function (data) {

            userService.getAllRoles()
                         .success(function (data) {
                             debugger;
                             //alert(data);
                             $scope.$parent.items = data;
                             // $scope.isLoading = false;      
                             $scope.showAlert($scope.SuccessUrl);

                         })
                         .error(function (data) {
                             debugger;
                             //$scope.isLoading = false;
                             console.log('Error: ', data)
                         });

        });

        $modalInstance.dismiss('cancel');
    };

    $scope.ok = function () {
        $modalInstance.close();
    };

    $scope.cancel = function () {
        $modalInstance.dismiss('cancel');
    };
}]);

    angular.module('sbAdminApp').controller('roleCreateCtrl',
['$scope', '$modalInstance', 'userService', 'fieldsLengthRestrictions', function ($scope, $modalInstance, userService, fieldsLengthRestrictions) {

    $scope.restrictions = fieldsLengthRestrictions.validator.pattern;
    $scope.errorMessage = fieldsLengthRestrictions.validator.errormessage;

    $scope.createStatus = function () {
        debugger;
        var model = $scope.statusCreate;
        userService.createRole(model).success(
            function (data) {

                $scope.showAlert($scope.SuccessUrl);

                userService.getAllRoles()
                      .success(function (data) {
                          debugger;
                          //alert(data);
                          $scope.$parent.items = data;
                          // $scope.isLoading = false;                            

                      })
                      .error(function (data) {
                          debugger;
                          //$scope.isLoading = false;
                          console.log('Error: ', data)
                      });


            });
        $modalInstance.dismiss('cancel');
    };

    $scope.ok = function () {
        $modalInstance.close();
    };

    $scope.cancel = function () {
        $modalInstance.dismiss('cancel');
    };
}]);

    angular.module('sbAdminApp').controller('AlterModalController',
['$scope', '$modalInstance', '$modalStack', 'param1', function ($scope, $modalInstance, $modalStack, param1) {


    $scope.CloseAll = function (isClose) {
        $modalStack.dismissAll('cancel');
        if (isClose == 'No')
            // $modalStack.dismissAll('cancel');
            $scope.OpenProfile('lg');
    };

    //$scope.Close = function () {
    //    $modalStack.dismissAll('cancel');
    //};
    $scope.ok = function () {
        $modalStack.dismissAll('cancel');
    };
}]);

})
(angular);