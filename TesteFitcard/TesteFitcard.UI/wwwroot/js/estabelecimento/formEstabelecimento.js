$('#formEstabelecimento').validate({
    errorClass: "text-danger",
    rules: {
        RazaoSocial: {
            required: true
        },
        Email: {
            email: true
        },
        Cnpj: {
            required: true,
            VerificaCNPJ: true
        },
        CategoriaId: {
            required: true
        }
    },
    messages: {
        RazaoSocial: {
            required: razaoSocialObrigatorio
        },
        Email: {
            email: preenchaEmailValido
        },
        Cnpj: {
            required: cnpjObrigatorio
        },
        CategoriaId: {
            required: categoriaObrigatoria
        }
    }
});
