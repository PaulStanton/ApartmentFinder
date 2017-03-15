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