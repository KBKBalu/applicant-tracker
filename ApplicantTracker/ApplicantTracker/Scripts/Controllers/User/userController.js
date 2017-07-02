(function (angular) {
    angular.module('sbAdminApp').controller('userController',
        ['$scope', '$modal', 'userService', 'fieldsLengthRestrictions', function ($scope, $modal, userService, fieldsLengthRestrictions) {

            $scope.items = {};

            $scope.user = {};
            $scope.user.UserId = '';
            $scope.user.FirstName = '';
            $scope.user.MiddleName = '';
            $scope.user.LastName = '';
            $scope.user.Password = '';
            $scope.user.Details = '';
            $scope.user.DateOfBirth = '';
            $scope.user.Address = '';
            $scope.user.MaritalStatus = '';
            $scope.user.Mobile = '';
            $scope.user.Gender = '';
            $scope.user.Email = '';
            $scope.user.Branch = '';
            $scope.Users = [];

                
            $scope.ConfirmationMessage = "User Created Successfully."
            $scope.ErrorMessage = "Failed.";
            $scope.SuccessMessage = "Sucess";
            $scope.IsError = false;
            $scope.IsConfirmed = false;

            $scope.ConfirmationUrl = '/Templates/Common/Confirmation.html';
            $scope.ErrorUrl = '/Templates/Common/Error.html';
            $scope.SuccessUrl = '/Templates/Common/Success.html'
            $scope.condition = '';


            $scope.IsExpanded = false;
            $scope.IsInfoExpanded = true;

            $scope.Initialize = function () {
                // $scope.isLoading = true;
                userService.getAllUsers()
                        .success(function (data) {
                            //alert(data);
                            $scope.items = data;
                            // $scope.isLoading = false;                            

                        })
                        .error(function (data) {
                            debugger;
                            //$scope.isLoading = false;
                            console.log('Error: ', data)
                        });
            };

            $scope.open = function (size) {
                debugger;

                $scope.user = {};
                $scope.user.UserId = '';
                $scope.user.FirstName = '';
                $scope.user.MiddleName = '';
                $scope.user.LastName = '';
                $scope.user.Password = '';
                $scope.user.Details = '';
                $scope.user.DateOfBirth = '';
                $scope.user.Address = '';
                $scope.user.MaritalStatus = '';
                $scope.user.Mobile = '';
                $scope.user.Gender = '';
                $scope.user.Email = '';
                $scope.user.Branch = '';

                var modalInstance = $modal.open({
                    size: '1000px',
                    animation: false,
                    backdrop: 'static',
                    templateUrl: '/Templates/User/CreateUser.html',
                    controller: 'createUserCtrl',
                    scope: $scope,
                    windowClass: 'large-Modal',
                    resolve: {
                        user: function () {
                            return $scope.user;
                        }
                    }
                });

                userService.userroles().success(function (data) {
                    debugger;
                    $scope.userroles = {};
                    $scope.userroles = data;
                });

                modalInstance.result.then(function (response) {
                    debugger;
                }, function () {
                    $log.info('Modal dismissed at: ' + new Date());
                });
            };


            $scope.Edit = function (item, flag) {

                userService.getUserById(item)
                   .success(function (data) {

                       debugger;
                       //$scope.items = data;
                       $scope.user = {};
                       $scope.user.UserId = item.UserId;

                       $scope.userrole = {};
                       $scope.userrole.UserId = $scope.user.UserId;

                       userService.getUserRoleById($scope.userrole).success(

                           function (roledata) {

                               debugger;
                               $scope.userRole = {};
                               $scope.userRole.selected = roledata.RoleId;
                               $scope.userRole.UserRoleId = roledata.UserRoleId;

                               //angular.forEach($scope.items, function (value, key) {
                               debugger;

                               if (data.UserId == $scope.user.UserId) {

                                   $scope.user.FirstName = data.FirstName;
                                   $scope.user.MiddleName = data.MiddleName;
                                   $scope.user.LastName = data.LastName;
                                   $scope.user.Password = data.Password;
                                   $scope.user.Details = data.Details;
                                   $scope.user.DateOfBirth = data.DateOfBirth;
                                   $scope.user.Address = data.Address;
                                   $scope.user.MaritalStatus = data.MaritalStatus;
                                   $scope.user.Mobile = data.Mobile;
                                   $scope.user.Gender = data.Gender;
                                   $scope.user.Email = data.Email;
                                   $scope.user.Branch = data.Branch;
                                   $scope.user.IsActive = data.IsActive;
                               }

                               //});

                               debugger;
                               var modalInstance = $modal.open({
                                   size: '500px',
                                   animation: false,
                                   backdrop: 'static',
                                   templateUrl: '/Templates/User/EditUser.html',
                                   controller: 'userEditCtrl',
                                   scope: $scope,
                                   windowClass: 'large-Modal',
                                   resolve: {
                                       user: function () {
                                           return $scope.user;
                                       }
                                   }
                               });
                               modalInstance.result.then(function (response) {
                                   debugger;
                               }, function () {
                                   $log.info('Modal dismissed at: ' + new Date());
                               });


                           });


                   })
                   .error(function (data) {
                       debugger;
                       //$scope.isLoading = false;
                       console.log('Error: ', data)
                   });


            };

            $scope.userRoles = function () {
                debugger;

                if (!flag) {

                    user.IsActive = false;
                    userService.userroles().success(function (data) {
                        debugger;
                        $scope.userroles = data;
                    });
                }

                $modalInstance.dismiss('cancel');
            };

            $scope.deleteUser = function (user, flag) {
                debugger;

                if (!flag) {

                    if (user.IsActive != false) {

                        user.IsActive = false;
                        userService.disableUser(user).success(
                            function (data) {
                                debugger;
                                //$scope.SuccessMessage = "User InActivated Successfully."
                                $scope.showAlert($scope.SuccessUrl);
                                //alert('User is Inactive:' + user.UserId);
                                userService.getAllUsers()
                         .success(function (data) {
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
                    }

                    else {
                        $scope.showAlert($scope.ErrorUrl);
                    }
                    //alert('User is Inactive:' + user.UserId);
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


    angular.module('sbAdminApp').controller('createUserCtrl',
      ['$scope', '$modalInstance', 'userService', 'fieldsLengthRestrictions', function ($scope, $modalInstance, userService, fieldsLengthRestrictions) {

          $scope.SaveUser = function () {
              debugger;
              var model = $scope.user;

              $scope.userRole = {};
              $scope.userRole.UserRoleId = '';
              $scope.userRole.RoleId = '';
              $scope.userRole.UserId = '';

              $scope.userrole = {};
              $scope.userrole.selected = userForm.disabledSelect.selectedIndex + 1;
              userService.submitUser(model).success(
                  function (data) {
                      debugger;
                      var result = data;
                      $scope.userRole = {};
                      $scope.userRole.UserRoleId = '';
                      $scope.userRole.RoleId = $scope.userrole.selected;
                      $scope.userRole.UserId = data.UserId;

                      userService.createUserRole($scope.userRole).success(function (data) {

                          //$scope.SuccessMessagee = '';
                          //$scope.SuccessMessagee = "User Created Successfully."
                          $scope.showAlert($scope.SuccessUrl);
                          //alert('New user is Created' + $scope.userRole.UserId);

                          userService.getAllUsers()
                          .success(function (data) {
                              //alert(data);
                              $scope.$parent.items = data;
                              // $scope.isLoading = false;                            

                          })
                          .error(function (data) {
                              debugger;
                              //$scope.isLoading = false;
                              console.log('Error: ', data)
                          });

                      }

                      );
                  }

                  );
              $modalInstance.dismiss('cancel');
          };

          debugger;
          $scope.restrictions = fieldsLengthRestrictions.validator.pattern;
          $scope.errorMessage = fieldsLengthRestrictions.validator.errormessage;

          $scope.ok = function () {
              $modalInstance.close();
          };

          $scope.cancel = function () {
              $modalInstance.dismiss('cancel');
          };


          $scope.userRoles = function () {
              debugger;

              if (!flag) {

                  user.IsActive = false;
                  userService.userroles().success(function (data) {
                      debugger;
                      $scope.userroles = data;
                  });
              }

              $modalInstance.dismiss('cancel');
          };


      }]);


    angular.module('sbAdminApp').controller('userEditCtrl',
['$scope', '$modalInstance', 'userService', 'fieldsLengthRestrictions', function ($scope, $modalInstance, userService, fieldsLengthRestrictions) {

    $scope.restrictions = fieldsLengthRestrictions.validator.pattern;
    $scope.errorMessage = fieldsLengthRestrictions.validator.errormessage;


    $scope.update = function () {
        debugger;
        var model = $scope.user;
        $scope.UserRole = {};
        var userRoleId = $scope.$parent.userRole.UserRoleId;

        $scope.UserRole.UserRoleId = userRoleId;
        $scope.UserRole.RoleId = $scope.userRole.selected;
        $scope.UserRole.UserId = $scope.user.UserId;

        if (typeof $scope.UserRole.UserRoleId != "undefined") {
            userService.updateUser(model).success(function (data) {
                userService.updateUserRole($scope.UserRole).success(
                    function () {
                        userService.getAllUsers()
                                    .success(function (data) {
                                        debugger;
                                        $scope.$parent.items = data;
                                        // $scope.$apply();
                                        $modalInstance.dismiss('cancel');
                                    })
                       .error(function (data) {
                           debugger;
                           console.log('Error: ', data)
                       });

                    });

            });

        }

        else {            
            $scope.showAlert($scope.ErrorUrl);
        }


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