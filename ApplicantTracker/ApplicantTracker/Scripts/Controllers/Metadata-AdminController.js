(function (angular) {
    angular.module('sbAdminApp').controller('MetadataAdminController',
        ['$scope', '$timeout', '$modal', 'MetadataService', function ($scope, $timeout, $modal, MetadataService) {
            $scope.metaDataType = 0;
            $scope.items = [];
            $scope.configuration = {
                metadata: MetadataService.initMetadata(),
                metaDataChoices: MetadataService.getMetaDataChoices()
            };
            $scope.filter = 0;
            MetadataService.getMetadata().then(function (data) {
                $scope.configuration.metadata = data;
            });
            $scope.errorCallback = function (message) {
                if (message.data === null && message.status === 0) {
                    alert('You have been logged out due to inactivity.  You will now be redirected to the login page.');
                    window.location = $scope.loginUrl;
                }
            };
            $scope.changeFilter = function (index) {
                $scope.metaDataIndex = index;
                for (var i = 0; i < $scope.configuration.metaDataChoices.length; i++) {
                    if ($scope.configuration.metaDataChoices[i].keyword == index) {
                        $scope.metaDataType = $scope.configuration.metaDataChoices[i].ID;
                    }
                }
                $scope.items = $scope.configuration.metadata[index];
            }
            $scope.delete = function (index) {
                MetadataService.deleteItem($scope.metaDataType, $scope.items[index]).then(function (data) {
                    $scope.refreshUi();
                }, function (error) {
                    alert('Could not delete item due to error: ' + error.data.ExceptionMessage);
                });
            };
            $scope.refreshUi = function () {
                MetadataService.clearCache();
                MetadataService.getMetadata().then(function (response) {
                    $scope.configuration.metadata = response;
                    $timeout(function () {
                        $scope.$apply();
                        $scope.changeFilter($scope.metaDataIndex);
                    });
                }, $scope.errorCallback);
            }
            $scope.createEdit = function (index, isEditing) {
                if (isEditing) {
                    $scope.item = $scope.items[index];
                    $scope.item.MetaDataType = $scope.metaDataType;
                } else {
                    $scope.item = {};
                }

                var editModal = $modal.open({
                    templateUrl: 'Templates/Administration/metadata-admin-dialog.html',
                    controller: 'MetadataModalController',
                    size: 'sm',
                    resolve: {
                        item: function () {
                            return $scope.item;
                        },
                        isEditing: function () {
                            return isEditing;
                        },
                        metaDataChoices: function () {
                            return $scope.configuration.metaDataChoices;
                        }
                    }
                });
                editModal.result.then(function (item) {
                    if (isEditing) {
                        MetadataService.update(item).then(function (data) {
                            $scope.item = item;
                            $scope.items[index] = item;
                        }, $scope.errorCallback);
                    } else {
                        MetadataService.create(item).then(function (data) {
                            alert('Successfully created item #' + data.data.ID);
                            $scope.refreshUi();
                        }, $scope.errorCallback);
                    }
                }, function () {
                    // Cancelled, do nothing.
                });
            };
        }]);
})
(angular);