<<<<<<< HEAD
app.factory('apartmentFactory', function($http){

    var domain = 'http://ec2-52-88-81-0.us-west-2.compute.amazonaws.com/ApartmentFinderWebAPI_deploy/api/apartments/GetAvailableApartmentsByAddress?address=';

    var getApartments = function(d, successCallback, errorCallback){
        $http.get(domain + d)
=======
app.factory('apartmentFactory', function($http){ 
    var getApartments = function(searchedaddress,successCallback, errorCallback){
       var domain ='' 
        if (searchedaddress=='')
        {
                    
        }
        else
        {
             domain = 'http://ec2-52-88-81-0.us-west-2.compute.amazonaws.com/ApartmentFinderWebAPI_deploy/api/apartments/GetAvailableApartmentsByAddress?address=';
             domain+=searchedaddress;
        }


        $http.get(domain)
>>>>>>> 2ff317982247655513874094750ac58027d64c98
        .then(function(data){
            successCallback(data);
        }, function (err){
            errorCallback(err);
        });
    }
    return{
        getApartments : getApartments
    }

});