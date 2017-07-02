(function (angular) {
    'use strict';

    //angular.module('sbAdminApp').directive("sparklinechart", function () {

    //    return {
    //        restrict: "E",
    //        scope: {
    //            data: "@"
    //        },
    //        compile: function (tElement, tAttrs, transclude) {
    //            tElement.replaceWith("<span>" + tAttrs.data + "</span>");
    //            return function (scope, element, attrs) {
    //                debugger;
    //                attrs.$observe("data", function (newValue) {
    //                    element.html(newValue);
    //                    element.sparkline('html', { type: 'bar', width: '96%', height: '80px', barWidth: 11, barColor: 'blue' });
    //                });
    //            };
    //        }
    //    };
    //});

/**
 * @ngdoc directive
 * @name izzyposWebApp.directive:adminPosHeader
 * @description
 * # adminPosHeader
 */
angular.module('sbAdminApp')
    .directive('stats',function() {
    	return {
  		templateUrl:'scripts/directives/dashboard/stats/stats.html',
  		restrict:'E',
  		replace:true,
  		scope: {
        'model': '=',
        'comments': '@',
        'number': '@',
        'name': '@',
        'colour': '@',
        'details':'@',
        'type':'@',
        'goto':'@'
  		}
  		
  	}
    });

//angular.module('sbAdminApp')
//    .controller('sparkLineController', function ($scope) {

//    $scope.Customers = "4,6,8,10,5";

//});
})
(angular);
