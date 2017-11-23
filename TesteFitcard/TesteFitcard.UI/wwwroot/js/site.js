/* 
 * Mensagens de validação
 */
var categoriaObrigatoria = 'A Categoria deve ser informada.';
var cnpjObrigatorio = 'O campo CNPJ deve ser informado.';
var cnpjInvalido = 'CNPJ informado não é válido.';
var nomeCategoriaObrigatorio = 'O campo Nome da Categoria deve ser informado.';
var preenchimentoObrigatorio = 'Campo de preenchimento obrigatório.';
var preenchaEmailValido = 'E-mail inválido.';
var razaoSocialObrigatorio = 'O campo Razão Social deve ser informado.';
var cepNaoEncontrado = 'CEP não encontrado.';



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

jQuery(function ($) {

    $(".cep").mask("99.999-999");
    $(".data").mask("99/99/9999");
    $(".telefone").mask("9999-9999?9");
    $(".ddd").mask("99");
    $(".cnpj").mask("99.999.999/9999-99");
});

$(".numero").keypress(function (e) {

    if (e.which !== 8 && e.which !== 0 && (e.which < 48 || e.which > 57)) {
        return false;
    }
});

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

jQuery.validator.addMethod("VerificaCNPJ", function (cnpj, element) {

    cnpj = cnpj.replace('/', '');
    cnpj = cnpj.replace('.', '');
    cnpj = cnpj.replace('.', '');
    cnpj = cnpj.replace('-', '');

    var numeros, digitos, soma, i, resultado, pos, tamanho,
        digitos_iguais;
    digitos_iguais = 1;

    if (cnpj.length < 14 && cnpj.length < 15) {
        return false;
    }
    for (i = 0; i < cnpj.length - 1; i++) {
        if (cnpj.charAt(i) != cnpj.charAt(i + 1)) {
            digitos_iguais = 0;
            break;
        }
    }

    if (!digitos_iguais) {
        tamanho = cnpj.length - 2
        numeros = cnpj.substring(0, tamanho);
        digitos = cnpj.substring(tamanho);
        soma = 0;
        pos = tamanho - 7;

        for (i = tamanho; i >= 1; i--) {
            soma += numeros.charAt(tamanho - i) * pos--;
            if (pos < 2) {
                pos = 9;
            }
        }
        resultado = soma % 11 < 2 ? 0 : 11 - soma % 11;
        if (resultado != digitos.charAt(0)) {
            return false;
        }
        tamanho = tamanho + 1;
        numeros = cnpj.substring(0, tamanho);
        soma = 0;
        pos = tamanho - 7;
        for (i = tamanho; i >= 1; i--) {
            soma += numeros.charAt(tamanho - i) * pos--;
            if (pos < 2) {
                pos = 9;
            }
        }
        resultado = soma % 11 < 2 ? 0 : 11 - soma % 11;
        if (resultado != digitos.charAt(1)) {
            return false;
        }
        return true;
    } else {
        return false;
    }
}, cnpjInvalido);

    





