$("#categoriaAtivo").bootstrapSwitch();

$(document).on('click', '.btnExcluirCategoria', function (e) {
    e.preventDefault();

    var nome = $(this).attr('data-nome');
    var dados = new Object();

    dados.titulo = confirmarExclusaoCategoria;
    dados.labelSucesso = btnLabelConfirmar;
    dados.classSucesso = btnClassSucesso;
    dados.labelDanger = btnLabelCancelar;
    dados.classDanger = btnClassDanger;
    dados.mensagem = msgConfirmarExlusaoCategoria.replace('@###@', nome);
    dados.urlSucesso = $(this).attr('data-url');

    ModalConfirmacao(dados);
});



