var app = angular.module("PAKAF", ['ngRoute']);

app.config(function($routeProvider)
{
    $routeProvider.when
    ('/', 
        {
            templateUrl: 'views/frontend.html',
            controller: 'frontendCtrl'
        }
    )

    .when('/signin',
    {
        templateUrl: 'views/signin.html',
        controller: "signinCtrl"
    })

    .when('/editlistings',
    {
        templateUrl: 'views/editlistings.html',
        controller: 'editlistingsCtrl'
    })
}
);