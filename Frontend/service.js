app.service('apartmentService', function($http){
    var domain = 'http://ec2-52-88-81-0.us-west-2.compute.amazonaws.com/ApartmentFinderWebAPI_deploy/api/apartments/GetAvailableApartmentsByAddress?address=';

    var getApartments = function(aptsrc, successCallback, errorCallback){
        $http.get(domain + aptsrc)
        .then(function(data){
            successCallback(data);
        }, function (err){
            errorCallback(err);
        });
    }
});