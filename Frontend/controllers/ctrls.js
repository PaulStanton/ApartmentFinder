app.controller('frontendCtrl', function($scope, apartmentFactory){
    var la = window.location.search;
    var i = la.indexOf('=');
    var sreturn = la.substring(i+1, la.length);
    
    // apartment is the model grabbed from the apartmentFactory's domain
    var successFunction = function(apartment){
        $scope.apartment = apartment;
        $scope.apartmentData = apartment.data;
        $scope.roomlist = null;

        $scope.selectRow = function(){
            angular.forEach($scope.apartmentData, 
            function(zip){
                if(zip.Apartment_Address.Zip == "30605"){
                    $scope.roomlist = apartment.data.RoomList;
                    console.log(zip);
                }
                return $scope.roomlist
            }
            )};

        $scope.email = function(){
            return ContactEmail;
        };
        
    };

    var errorFunction = function(err){
        $scope.apartment = err;
    };

    apartmentFactory.getApartments(sreturn, successFunction, errorFunction);
        
});

app.controller('signinCtrl', function($scope){
    $scope.msg = "This is the sign in page!";
});

app.controller('editlistingsCtrl', function($scope){
    $scope.msg = "This is the edit listings in page!";
});