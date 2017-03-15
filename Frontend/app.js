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
<<<<<<< HEAD
=======

>>>>>>> 2ff317982247655513874094750ac58027d64c98
);