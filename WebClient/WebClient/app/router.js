

appRoot.config(['$routeProvider', function ($routeProvider) {
    $routeProvider
        .when('/', { templateUrl: '/home/main', controller: 'MainController' })
            .when('/home', { templateUrl: '/home/main', controller: 'MainController', caseInsensitiveMatch: true })

        .when('/settings/:id', {
            templateUrl: function (params) { return '/settings/index/' + params.id },
            controller: 'SettingsController'
        }).
        when('/settings', {
            templateUrl: '/settings/index/',
            controller: 'SettingsController'
        }).
        otherwise({
            redirectTo: '/404'
        })
    ;
}]);