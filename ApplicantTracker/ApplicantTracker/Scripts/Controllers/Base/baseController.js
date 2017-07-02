/*
*
 * angular base Load views
 *
 
 */
(function (angular) {

    angular.module('sbAdminApp').controller('BaseController',
        ['$scope', '$location', 'baseApiService', '$rootScope', '$templateCache', '$http', function ($scope, $location, baseApiService, $rootScope, $templateCache, $http) {

            
            $scope.loadTemplate = function (resource) {              
                
                return baseApiService.LoadTemplate(resource);
            };
            

            function load(params) {

                return true;
            }

            return {
                // "PUBLIC" functions go here
                load: load
            };


        }]);


})
(angular);
