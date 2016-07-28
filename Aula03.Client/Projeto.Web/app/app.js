//criar o modulo do AngularJS
//este modulo representa um 'projeto' utilizando AngularJS
var app = angular.module('app', ['ngRoute']);

//configurar as rotas do projeto..
app.config(

    //principais objetos do angular..
    //$scope -> utilizado para resgatar ou enviar conteudo para uma página
    //$http  -> utilizado para executar serviços REST em servidores
    //$routeProvider -> utilizado para mapear rotas de páginas

    function ($routeProvider) {

        $routeProvider
            //.when(
            //    '/cliente/cadastro', //rota (URL)
            //    {
            //        templateUrl: "/app/views/cadastro.html", //caminho da página
            //        controller: "ClienteCadastro" //nome do controle no javascript
            //    }
            //)
            .when(
                '/cliente/consulta', //rota (URL)
                {
                    templateUrl: "/app/views/consulta.html", //caminho da página
                    controller: "ClienteConsulta" //nome do controle no javascript
                }
            )
            .when("/",
            {
                templateUrl: "/app/views/cadastro.html",
                controller: "ClienteCadastro"
            });
    }
);