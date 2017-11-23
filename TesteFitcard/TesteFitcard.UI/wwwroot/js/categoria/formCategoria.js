$('#formCategoria').validate({
    errorClass: "text-danger",
    rules: {
        NomeCategoria: {
            required: true
        }       
    },
    messages: {
        NomeCategoria: {
            required: nomeCategoriaObrigatorio
        }       
    }
});
