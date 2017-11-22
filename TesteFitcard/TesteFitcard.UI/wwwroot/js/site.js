/* 
 * Mensagens de validação
 */
var preenchimentoObrigatorio = 'Campo de preenchimento obrigatório.';
var preenchaEmailValido = 'Preencha com um endereço de e-mail válido.';

/*
 * Labels de botões
 */
var btnLabelCancelar = '<i class="fa fa-close"></i> Cancelar';
var btnLabelConfirmar = '<i class="fa fa-check"></i> Confirmar';

/*
 * Títulos 
 */
var confirmarExclusaoCategoria = 'Confirmar exclusão de categoria';
var confirmarExclusaoEstabelecimento = 'Confirmar exclusão de estabelecimento';

/*
 * Classes 
 */
var btnClassDanger = 'btn-danger';
var btnClassSucesso = 'btn-success';

/*
 * Mensagens
 */

var msgConfirmarExlusaoCategoria = 'Tem certeza que deseja excluir a categoria @###@?';
var msgConfirmarExlusaoEstabelecimento = 'Tem certeza que deseja excluir o estabelecimento @###@?';

//jQuery(function ($) {

//    $(".data").mask("99/99/9999");
//    $(".telefone").mask("(99) 9999-9999?9");
//    $(".cpf").mask("999.999.999-99");
//});

function ModalConfirmacao(dados) {

    bootbox.dialog({
        message: dados.mensagem,
        title: dados.titulo,
        buttons: {
            success: {
                label: dados.labelSucesso,
                className: dados.classSucesso,
                callback: function () {
                    document.location.href = dados.urlSucesso;
                }
            },
            danger: {
                label: dados.labelDanger,
                className: dados.classDanger,
                callback: function () {

                }
            }
        }
    });
}




