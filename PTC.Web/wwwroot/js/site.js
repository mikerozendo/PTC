// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

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

function FormEventHandler(form, aspAction, aspController) {
    document.forms[form].addEventListener('submit', (event) => {
        event.preventDefault();
        ColetarRespostaServidor(aspAction, aspController);
    });
}

function ColetarRespostaServidor(aspAction, aspController) {
    fetch(event.target.action, {
        method: 'POST',
        body: new URLSearchParams(new FormData(event.target))
    }).then(function (serverPromise) {
        serverPromise.text()
            .then(function (j) {
                alert(j);
                if (j.toString().includes("sucesso")) {
                    window.location.href = "/" + aspController + "/" + aspAction
                }
            })
            .catch(function (e) {
                console.log(e);
            });
    });
}

function CopiarConteudo(obj) {
    obj.text.select();
    document.execCommand('copy');
}
