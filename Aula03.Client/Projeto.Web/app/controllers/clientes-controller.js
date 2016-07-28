//criando o controller para a página de cadastro...
app.controller(
    'ClienteCadastro',
    function ($scope, $http) {

        $scope.titulo = "Página de cadastro de clientes";

        //declarar o objeto para resgatar os dados do formulário..
        $scope.model = { }; //vazio (receber os dados)

        //função de cadastro...
        $scope.cadastrar = function () {

            $scope.mensagem = "Enviando requisição, por favor aguarde...";

            $http.post("http://localhost:3137/api/cliente/cadastro", $scope.model)
                .success(
                    function (msg) {
                        $scope.mensagem = msg;
                        $scope.model = {}; //limpar o JSON
                    }
                )
                .error(
                    function (e) {
                        $scope.mensagem = e;
                    }
                );
        };
    }
);


//criando o controller para a página de consulta...
app.controller(
    'ClienteConsulta',
    function ($scope, $http) {

        $scope.titulo = "Página de consulta de clientes";

        $scope.model = {}; //JSON para o formulario de atualização..

        //função para exibir os dados do cliente quando a janela for aberta..
        $scope.exibir = function (id) {

            $http.get("http://localhost:3137/api/cliente/obter?id=" + id)
                .success(
                    function (dados) {
                        $scope.model.ClienteID = dados.ClienteID;
                        $scope.model.Nome = dados.Nome;
                        $scope.model.Email = dados.Email;
                    }
                )
                .error(
                    function (e) {
                        $scope.mensagem = e;
                    }
                );
        };


        //função para atualizar os dados do cliente..
        $scope.atualizar = function () {

            $http.put("http://localhost:3137/api/cliente/editar", $scope.model)
                .success(
                    function (msg) {
                        $scope.mensagem = msg;
                        $scope.consultar();
                    }
                )
                .error(
                    function (e) {
                        $scope.mensagem = e;
                    }
                );
        };

        //função para excluir os dados do cliente..
        $scope.excluir = function (id) {

            $http.delete("http://localhost:3137/api/cliente/excluir?id=" + id)
                .success(
                    function (msg) {
                        $scope.mensagem = msg;
                        $scope.consultar();
                    }
                )
                .error(
                    function (e) {
                        $scope.mensagem = e;
                    }
                );
        };


        //função para listar os clientes através do serviço..
        $scope.consultar = function () {

            //executar a URL do serviço de consulta na Api..
            $http.get("http://localhost:3137/api/cliente/listar")
                .success(
                    function (lista) {
                        $scope.clientes = lista;
                    }
                )
                .error(
                    function (e) {
                        $scope.mensagem = e; //mensagem de erro..
                    }
                );
        };
    }
);

