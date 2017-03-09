app.factory('apartmentFactory', function($http){

    var domain = 'http://localhost:50403/api/Apartments/GetApartments';

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