<<<<<<< HEAD
app.controller('frontendCtrl', function($scope, apartmentFactory){
    var la = window.location.search;
    var i = la.indexOf('=');
    var sreturn = la.substring(i+1, la.length);
=======

app.controller('frontendCtrl', function($scope, apartmentFactory){
    var searchedAddress = window.location.search;


>>>>>>> 2ff317982247655513874094750ac58027d64c98
    
    // apartment is the model grabbed from the apartmentFactory's domain
    var successFunction = function(apartment){
        $scope.apartment = apartment;
        $scope.apartmentData = apartment.data;
        $scope.roomlist = null;

<<<<<<< HEAD
=======
       $scope.currentApartment ='';
   $scope.select = function(elem){
    $scope.currentApartment = elem;
    var address = '//www.google.com/maps/embed/v1/place?q='+elem.Apartment_Address.Street_Address+','+elem.Apartment_Address.City+','+elem.Apartment_Address.State+elem.Apartment_Address.Zip + '&zoom=13'+
          "&key=AIzaSyBGkAVqJAnAL4gk0eoLbtod1YySY8m-HjA";
    
    console.log(elem);
    document.getElementById("map").src = address;
    document.getElementById("ApartmentPicture").src=elem.PictureURL;
   }
        // console.log(apartment.data);     

>>>>>>> 2ff317982247655513874094750ac58027d64c98
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
<<<<<<< HEAD

    apartmentFactory.getApartments(sreturn, successFunction, errorFunction);
        
});

=======
    apartmentFactory.getApartments(searchedAddress, successFunction, errorFunction);

});
 
>>>>>>> 2ff317982247655513874094750ac58027d64c98
app.controller('signinCtrl', function($scope){
    $scope.msg = "This is the sign in page!";
});

app.controller('editlistingsCtrl', function($scope){
    $scope.msg = "This is the edit listings in page!";
});