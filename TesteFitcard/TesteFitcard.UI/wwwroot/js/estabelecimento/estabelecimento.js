$("#estabelecimentoAtivo").bootstrapSwitch();

$(document).on('click', '.btnExcluirEstabelecimento', function (e) {
    e.preventDefault();

    var nome = $(this).attr('data-nome');
    var dados = new Object();

    dados.titulo = confirmarExclusaoEstabelecimento;
    dados.labelSucesso = btnLabelConfirmar;
    dados.classSucesso = btnClassSucesso;
    dados.labelDanger = btnLabelCancelar;
    dados.classDanger = btnClassDanger;
    dados.mensagem = msgConfirmarExlusaoEstabelecimento.replace('@###@', nome);
    dados.urlSucesso = $(this).attr('data-url');

    ModalConfirmacao(dados);
});