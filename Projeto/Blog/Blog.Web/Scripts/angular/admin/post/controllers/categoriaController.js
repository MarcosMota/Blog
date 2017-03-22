angular.module('blog.admin', []).controller('categoriaController', ['$scope', 'CategoriaAPI', function ($scope, CategoriaAPI) {

    

    $scope.listCategorias = CategoriaAPI.categorias;
}]);