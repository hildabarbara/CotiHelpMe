//definir o controller da página de cadastro
app.controller(
    'cadastro_controller', //nome do controle
    function ($scope, $http) {

        /*
            $scope -> função para enviar/receber dados da página
            $http -> executra chamadas ao servidor web (Asp.Net)
        */

        //Criar um JSON para resgatar os dados dos campos
        //e envia-los para o serviço WebApi
        $scope.Model = {
            Nome: '',
            Preco: '',
            Quantidade: ''
        };

        //Criar a função executada quando o usuario
        //clicar no botão de cadastro...
        $scope.cadastrar = function () {

            $scope.mensagem = "Executando...";

            //requisição POST ao método do controle, enviando o JSON com os dados
            $http.post("http://localhost:50213/api/Produtos", $scope.Model).
                success(
                    function (msg) {
                        $scope.mensagem = msg.substring(1, msg.length -1);
                        $scope.erros = '';

                        //limpar os dados do formulário
                        $scope.Model.Nome = ''; //vazio
                        $scope.Model.Preco = ''; //vazio
                        $scope.Model.Quantidade = ''; //vazio
                    }
                ).
                error(
                    function (e) {
                        $scope.erros = e; //exibir erros...
                        $scope.mensagem = '';
                    }
                );

            /*
            $scope.mensagem = "Dados: " + $scope.Model.Nome + ", " +
                                $scope.Model.Preco + ", " + $scope.Model.Quantidade;
            */
        };

    }
);