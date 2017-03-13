app.factory('apartmentFactory', function($http){

    var domain = 'http://ec2-52-88-81-0.us-west-2.compute.amazonaws.com/ApartmentFinderWebAPI_deploy/api/apartments';

    var getApartments = function(successCallback, errorCallback){
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