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


function consultarEndereco(cep) {
    
    $('#mensagemBuscaCep').empty();
    
    jQuery.ajax({
        type: 'POST',
        url:  'buscaendereco',
        data: {
            cep: cep
        },
        dataType: 'json',
        beforeSend: function () { 
            
            //$('#aguardeBuscaEndereco').show();
        },
        success: function (data)
        { 
           
            var resposta = (data.resposta != undefined) ? data.resposta.return : null;
            
            if (resposta == null) {
               
                $('#mensagemBuscaCep').html(mensagem("danger", data.resposta));
            }
            preencheCamposEndereco(resposta);
            
        },
        complete: function () {
            
        }
    });
}


$(document).on('change', '#Cep', function () {

    var cep = $('#Cep').val();
    if (cep) {

        consultarEndereco(cep);        
    }
});


function preencheCamposEndereco(resposta) {

    var estado = (resposta) ? resposta.uf : '';
    var cidade = (resposta) ? resposta.cidade : '';
    var endereco = (resposta) ? resposta.end : '';
    var bairro = (resposta) ? resposta.bairro : '';

    $('#Estado').val(estado);
    $('#Cidade').val(cidade);
    $('#Endereco').val(endereco);
    $('#Bairro').val(bairro);

    if (bairro != '') {

        $('#Bairro').attr("readonly", true);
    }
    else {

        $('#Bairro').removeAttr('readonly');
    }
}

function mensagem(tipo, texto) {
   
    var mensagem = '<div class="alert alert-' + tipo + ' alert-dismissible fade in" role="alert">';
    mensagem += '<button class="close" aria-label="Close" data-dismiss="alert" type="button">';
    mensagem += '<span aria-hidden="true">×</span>';
    mensagem += '</button>' + texto + '</div>';

    return mensagem;
}