appRoot.controller('MainController', function ($scope, $window, languageService) {

        //for load language
        $scope.languages = [];
        $scope.selectedCulture = {};

        $scope.selectedChange = function (culture) {
            languageService.changeLang(culture, function (culturedata) {
                if (culturedata) {
                    $window.location.reload();
                }
                else {
                }
            }, function (response) {
            });

        }

        languageService.GetPreSelectedLanguage(function (selecteddatalang) {
            $scope.selectedCulture = selecteddatalang;

            languageService.GetLanguages(function (datalang) {
                $scope.languages.length = 0;
                angular.forEach(datalang, function (lang) {
                    $scope.languages.push(lang);
                    if (lang.ID == $scope.selectedCulture.ID) {
                        $scope.selectedCulture = lang;
                    }
                })
            });

        });
       //end language
        
    });