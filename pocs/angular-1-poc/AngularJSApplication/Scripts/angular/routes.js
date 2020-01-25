app.config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {
    $routeProvider
        .when ('/api', {
            templateUrl: '/API.html',
            controller: 'ApiCtrl'
        })
        .when ('/forms', {
            templateUrl: '/Form.html',
            controller: 'FormCtrl'
        })
        .when ('/directives', {
            templateUrl: '/Directives.html',
            controller: 'DirectiveCtrl'
        })
        .otherwise({
            redirectTo: '/'
        });
        
    $locationProvider.html5Mode(true);
    
}]);