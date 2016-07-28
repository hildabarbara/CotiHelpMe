//registrar o modulo de aplicação no AngularJS
//ngRoute -> registrar um modulo baseado em rotas
var app = angular.module('app', ['ngRoute']);

//configurar (definir as rotas)
app.config(

    //função principal de configuração...
    //$routeProvider -> definição das rotas
    //$locationProvider -> html e páginas
    function ($routeProvider, $locationProvider) {
        
        //habilitar o uso de HTML5 pelo AngularJS
        $locationProvider.html5Mode(true);

        //mapeamento das rotas (URLs)
        //cada rota define uma view e um controller
        $routeProvider.
            when(
                '/', //caminho raiz
                {
                    templateUrl: 'app/views/home.html',
                    controller: 'home_controller'
                }
            ).
            when(
                '/pesquisa', //rota
                {
                    templateUrl: 'app/views/pesquisa.html',
                    controller: 'pesquisa_controller'
                }
            ).
            when(
                '/cadastro', //rota
                {
                    templateUrl: 'app/views/cadastro.html',
                    controller: 'cadastro_controller'
                }
            ).
            when(
                '/detalhes', //rota
                {
                    templateUrl: 'app/views/detalhes.html',
                    controller: 'detalhes_controller'
                }
            ).
            otherwise( //nenhum dos anteriores
                { redirectTo : '/' } //redirecionar para o caminho raiz
            );
    }
);

