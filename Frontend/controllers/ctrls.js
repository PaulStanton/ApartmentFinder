app.controller('frontendCtrl', function($scope, apartmentFactory){
    var successFunction = function(apartment){
        $scope.name = apartment.data.ApartmentName;

        console.log(apartment);
    }

    var errorFunction = function(err){
        $scope.apartment = err;
    };

    apartmentFactory.getApartments(successFunction, errorFunction);
    
});

app.controller('signinCtrl', function($scope){
    $scope.msg = "This is the sign in page!";
});

app.controller('editlistingsCtrl', function($scope){

});