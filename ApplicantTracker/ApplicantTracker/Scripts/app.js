/// <reference path="F:\Project\ApplicantTracker\ApplicantTracker\ApplicantTracker\Templates/dashboard/home.html" />
/// <reference path="F:\Project\ApplicantTracker\ApplicantTracker\ApplicantTracker\Templates/dashboard/home.html" />
/// <reference path="F:\Project\ApplicantTracker\ApplicantTracker\ApplicantTracker\Templates/dashboard/home.html" />
//
/**
 * @ngdoc overview
 * @name sbAdminApp
 * @description
 * # sbAdminApp
 *
 * Main module of the application.
 */
(function (angular) {
    'use strict';
    angular.module('sbAdminApp', [
        'oc.lazyLoad',
        'ui.router',
        'ui.bootstrap',
        'ngRoute',
        'angular-loading-bar',
    ])
      .config(['$stateProvider', '$routeProvider', '$urlRouterProvider', '$ocLazyLoadProvider', '$locationProvider', function ($stateProvider, $routeProvider, $urlRouterProvider, $ocLazyLoadProvider, $locationProvider) {

          $routeProvider.when('/dashboard', {
              templateUrl: '/Templates/dashboard/home.html',
              controller: 'DashboardController',
          });
          $routeProvider.when('/MorrisChart', {
              templateUrl: '/Templates/Chart/MorrisChart.html',
              //controller: 'homeCtrl',
          });
          $routeProvider.when('/FlotChart', {
              templateUrl: '/Templates/Chart/FlotChart.html',
              //controller: 'homeCtrl',
          });
          $routeProvider.when('/dashboard/main', {
              templateUrl: '/Templates/dashboard/main.html',
              //controller: 'homeCtrl',
          });
          $routeProvider.when('/table', {
              templateUrl: '/Templates/dashboard/table.html',
              //controller: 'aboutCtrl',
          });

          $routeProvider.when('/candidate', {
              templateUrl: '/Templates/Candidate/Search.html',
              //controller: 'aboutCtrl',
          });
          $routeProvider.when('/profile', {
              templateUrl: '/Templates/Profile/Search.html',
              //controller: 'aboutCtrl',
          });
          $routeProvider.when('/user', {
              templateUrl: '/Templates/User/user-home.html',
              //controller: 'aboutCtrl',
          });
          debugger;
          $routeProvider.when('/settings', {
              templateUrl: '/Templates/Admin/admin-home.html',
              //controller: 'aboutCtrl',
          });
         
          $routeProvider.otherwise({
              redirectTo: '/dashboard/'
          });
         
          $locationProvider.html5Mode(false);
          
      }]);
   
})
(angular);
