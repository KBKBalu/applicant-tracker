(function (angular) {
    angular.module('sbAdminApp').controller('MetadataModalController',
        ['$scope', '$modalInstance', 'fieldsLengthRestrictions', 'item', 'isEditing', 'metaDataChoices', function ($scope, $modalInstance, fieldsLengthRestrictions, item, isEditing, metaDataChoices) {
            $scope.item = {
                Name: null,
                Description: null
            };
            $scope.configuration = {
                isEditing: isEditing,
                metaDataChoices: metaDataChoices
            };
            $scope.restrictions = fieldsLengthRestrictions.entity.maxLength;
            $scope.init = function () {
                if ($scope.configuration.isEditing) {
                    angular.copy(item, $scope.item);
                }
            }
            $scope.init();
            $scope.ok = function () {
                $modalInstance.close($scope.item);
            };
            $scope.cancel = function () {
                $modalInstance.dismiss('cancel');
            };
        }]);
})
(angular);