(function (angular) {
    angular.module('sbAdminApp').controller('adminCompanyController',
        ['$scope', '$modal', 'userService', 'fieldsLengthRestrictions', function ($scope, $modal, userService, fieldsLengthRestrictions) {

            $scope.items = {};

            $scope.statusCreate = {};
            $scope.statusCreate.CanStatusId = '';
            $scope.statusCreate.Name = '';
            $scope.statusCreate.Description = '';
            $scope.statusCreate.IsActive = '';           


            $scope.ConfirmationMessage = "Company Created Successfully."
            $scope.ErrorMessage = "Failed.";
            $scope.SuccessMessage = "Sucess";
            $scope.IsError = false;
            $scope.IsConfirmed = false;

            $scope.ConfirmationUrl = '/Templates/Common/Confirmation.html';
            $scope.ErrorUrl = '/Templates/Common/Error.html';
            $scope.SuccessUrl = '/Templates/Common/Success.html'

            userService.getAllCompanys()
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
                    controller: 'companyCreateCtrl',
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


            $scope.createEdit = function (item, flag) {
                            
                   userService.getAllCompanys()
                      .success(function (data) {

                          debugger;
                          $scope.items = data;
                          $scope.statusEdit = {};
                          $scope.statusEdit.CanStatusId = item.CompanyId;

                          angular.forEach($scope.items, function (value, key) {
                              debugger;

                              if (value.CompanyId == $scope.statusEdit.CanStatusId) {

                                  $scope.statusEdit.CompanyId = value.CompanyId;
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
                              controller: 'adminCompanyEditCtrl',
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
     
            $scope.deleteItem = function (company, flag) {
                debugger;

                if (!flag) {
                    if (company.IsActive != false) {
                        company.IsActive = false;
                        userService.disableCompany(company).success(
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

    angular.module('sbAdminApp').controller('adminCompanyEditCtrl',
 ['$scope', '$modalInstance', 'userService', 'fieldsLengthRestrictions', function ($scope, $modalInstance, userService, fieldsLengthRestrictions) {

     $scope.restrictions = fieldsLengthRestrictions.validator.pattern;
     $scope.errorMessage = fieldsLengthRestrictions.validator.errormessage;

     $scope.Update = function () {
         debugger;
         var model = $scope.statusEdit;
         userService.UpdateCompany(model).success(
             function(data)
             {
                 userService.getAllCompanys()
                              .success(function (data) {
                                  debugger;
                                  //alert(data);
                                  $scope.showAlert($scope.SuccessUrl);
                                  $scope.$parent.items = data;
                                  // $scope.isLoading = false;                            

                              })
                              .error(function (data) {
                                  debugger;
                                  //$scope.isLoading = false;
                                  console.log('Error: ', data)
                              });
             })

         $modalInstance.dismiss('cancel');
     };

     $scope.ok = function () {
         $modalInstance.close();
     };

     $scope.cancel = function () {
         $modalInstance.dismiss('cancel');
     };
 }]);



    angular.module('sbAdminApp').controller('companyCreateCtrl',
['$scope', '$modalInstance', 'userService', 'fieldsLengthRestrictions', function ($scope, $modalInstance, userService, fieldsLengthRestrictions) {

    $scope.restrictions = fieldsLengthRestrictions.validator.pattern;
    $scope.errorMessage = fieldsLengthRestrictions.validator.errormessage;

    $scope.createStatus = function () {
        debugger;
        var model = $scope.statusCreate;
        userService.createCompany(model).success(
            function (data) {

                $scope.showAlert($scope.SuccessUrl);

                userService.getAllCompanys()
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


            }

            );
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