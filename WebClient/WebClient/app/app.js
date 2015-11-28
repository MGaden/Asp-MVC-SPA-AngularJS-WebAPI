var appRoot = angular.module('myApp', ['ngRoute', 'ngResource', 'angular-confirm', 'ui.bootstrap']);


appRoot.config(function ($controllerProvider, $compileProvider, $filterProvider, $provide, $locationProvider) {
    //'use strict';
    // Configure existing providers
    // enable html5Mode for pushstate ('#'-less URLs)
    $locationProvider.html5Mode({
        enabled: true,
        requireBase: false
    }).hashPrefix('!');

});






