angular.module('blog.admin', []).controller('postController', ['$scope',  function($scope) {
    $scope.listPosts = [
       { id: 1, titulo: "Open Sorce -  Inovação através da diversidade", dt_criacao: "24, Dezembro de 2016 as 14:30h", status: true },
       { id: 2, titulo: "5 dicas impressionantes", dt_criacao: "24, Dezembro de 2016 as 14:30h", status: true },
       { id: 3, titulo: "12 formas de monetizar", dt_criacao: "24, Dezembro de 2016 as 14:30h", status: true },
       { id: 4, titulo: "O que fazer quando", dt_criacao: "24, Dezembro de 2016 as 14:30h", status: false }
    ];
}]);