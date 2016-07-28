//definir o controller da página home
app.controller(
    'pesquisa_controller', //nome do controle
    function ($scope, $http) {

        /*
            $scope -> função para enviar/receber dados da página
            $http -> executra chamadas ao servidor web (Asp.Net)
        */

        //JSON para capturar o nome digitado...
        $scope.Model = {
            Nome : ''
        };

        //função para excluir um produto selecionado
        $scope.excluir = function (id) {
            
            $http.delete("http://localhost:50213/api/Produtos/" + id).
                success(
                    function (data) {
                        $scope.mensagem = data.substring(1, data.length -1);
                        $http.get("http://localhost:50213/api/Produtos").
                            success(
                                function (data) {
                                    $scope.produtos = data; //JSON
                                }
                            ).
                            error(
                                function () {
                                    $scope.mensagem = "Erro ao consultar produtos";
                                }
                            );
                        }
                ).
                error(
                    function (e) {
                        $scope.mensagem = e;
                    }
                );
        };

        //função para o evento do botão de pesquisa...
        $scope.pesquisar = function () {
            $http.get("http://localhost:50213/api/Produtos?Nome=" + $scope.Model.Nome).
            success(
                function (data) {
                    $scope.produtos = data; //JSON
                }
            ).
            error(
                function () {
                    $scope.mensagem = "Erro ao consultar produtos";
                }
            );
        };

        //executado quando a página é carregada...
        $http.get("http://localhost:50213/api/Produtos").
            success(
                function (data) {
                    $scope.produtos = data; //JSON
                }
            ).
            error(
                function () {
                    $scope.mensagem = "Erro ao consultar produtos";
                }
            );
    }
);