function factory(formMethod) {
    ImagemEvent();
    ValidarCep();
    ValidarDocumento();
    formEvent(formMethod);
}

function formEvent(formMethod) {
    document.forms['formProprietario']
        .addEventListener('submit', (event) => {
            event.preventDefault();

            triggerForm(formMethod);
        });    

}

function ImagemEvent() {
    $("#inputImg").on('change', function (e) {
        var value = `/Images/Proprietarios/${$("#inputImg").val().replace('C:\\fakepath\\', '')}`;
        $("#caminhoImagem").val(value);
    });

    $("#btnImgUpload").on('click', function (e) {
        $("#inputImg").click();
        return false;
    });
}

function ValidarCep() {
    $('#Cep').keyup(function () {
        if ($(this).val().length == 0) {
            $('#mdlEnrecoRetornoContent').hide();
        }
        if ($(this).val().length == 9) {
            var value = $(this).val().replace('-', '');
            ConsultarCep(value);
        }
    });
}

function ConsultarCep(obj) {
    $.ajax({
        url: "https://viacep.com.br/ws/" + obj + "/json/",
        type: "GET",
        success: function (json) {
            if (json != null) {
                if (json.erro != true) {
                    $('#Logradouro').val(json.logradouro);
                    $('#Bairro').val(json.bairro);
                    $('#Cidade').val(json.localidade);
                    $('#Uf').val(json.uf);
                }
            }
        },
    });
}

function ValidarDocumento() {
    $("#tipoDocumento").on('change', function (e) {
        e.stopImmediatePropagation();
        $("#documento").removeAttr("placeholder").removeAttr("readonly");
        $("#documento").val("");

        if ($("#tipoDocumento").val() == 0) {
            $("#documento").attr("placeholder", "000.000.000-00");
        }
        else if ($("#tipoDocumento").val() == 1) {
            $("#documento").attr("placeholder", "99.999.999/9999-99");
        }
        else {
            $("#documento").attr("readonly", true);
            $("#documento").attr("placeholder", "Selecione um tipo de documento");
        }
    });


    $("#documento").on("keyup", function (e) {
        e.stopImmediatePropagation();

        if ($(this).val().length == 11 && $("#tipoDocumento").val() == 0) {
            $(this).mask('999.999.999-99');
        }
        else if ($(this).val().length == 14 && $("#tipoDocumento").val() == 1) {
            $(this).mask("99.999.999/9999-99");
        }
    });
}

function triggerForm(formMethod) {
    console.log(formMethod);

    let baseUrl = `${window.location.origin}/Notifica/RenderizarMensagemStatus?action=${encodeURI("Index")}&controller=${encodeURI("Proprietario")}`;

    fetch(event.target.action, {
        method: formMethod,
        body: new FormData(event.target)
    }).then(function (serverPromise) {
        if (serverPromise.status == 400) {
            serverPromise.text()
                .then(function (notificacao) {
                    debugger;
                    let url = `${baseUrl}&titulo=${encodeURI("Falha")}&mensagem=${encodeURI(notificacao)}&sucesso=${encodeURI(false)}`;
                    GerarNotificacao(url, 'mdlMensagem');
                });
        } else {
            serverPromise.text()
                .then(function (notificacao) {
                    debugger;
                    let url = `${baseUrl}&titulo=${encodeURI("Sucesso")}&mensagem=${encodeURI(notificacao)}&sucesso=${encodeURI(true)}`;
                    GerarNotificacao(url, 'mdlMensagem');
                });
        }
    });

    return false;
}