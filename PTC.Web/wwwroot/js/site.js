//JS helper

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

function CopiarConteudo() {
    var copyTextarea = document.createElement("textarea");
    copyTextarea.style.position = "fixed";
    copyTextarea.style.opacity = "0";
    copyTextarea.textContent = document.getElementById("CopyWhatsApp").value;

    document.body.appendChild(copyTextarea);
    copyTextarea.select();
    document.execCommand("copy");
    document.body.removeChild(copyTextarea);
}

function AbrirWhatsAppWeb(obj) {
    let object = $(obj).attr("data-id");
    let link = "https://wa.me/55";
    link += object.replace("(", "").replace(")", "").replace(" ", "").replace(" ", "").replace("-", "");
    window.open(link, "_blank");
}

function EventoFiltro() {
    $(".input-filtro-dinamico").on('change', function (e) {
        e.stopImmediatePropagation();
        LinkFiltroDinamico($(this).val());
    });

    $(".input-filtro-dinamico").on('keyup', function (e) {
        e.stopImmediatePropagation();
        LinkFiltroDinamico($(this).val());
    });

    $(".input-filtro-dinamico").on('keydown', function (e) {
        e.stopImmediatePropagation();
        LinkFiltroDinamico($(this).val());
    });
}

function LinkFiltroDinamico(stringFiltro) {
    var urlAction = "/Proprietario/FiltroDinamico?filtro=";
    $(".filtro-dinamico-link").attr("href", urlAction + stringFiltro);
}

function RenderizarModalTravaDelete(controller, action, id, msgString) {
    $(".modalContainner").html('');
    let html =
    `<div class="modal mdl-trava-delete" tabindex="-1" role="dialog">
      <div class="modal-dialog" role="document">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title">Cuidado!</h5>
            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
              <span aria-hidden="true">&times;</span>
            </button>
          </div>
          <div class="modal-body">
            <p>${msgString}</p>
          </div>
          <div class="modal-footer">
            <button type="button" class="btn btn-secondary" data-dismiss="modal" style="text-align:right;">Cancelar</button>
            <button onclick="Deletar('${controller}','${action}',${id})" type="button" class="btn btn-primary btn-success" style="text-align: left;">Continuar</button>
          </div>
        </div>
      </div>
    </div>`;

    $(".modalContainner").html(html);
    $(".mdl-trava-delete").modal({ backdrop: 'static', keyboard: true });
}

function Deletar(controller, action, id) {
    debugger;
    let url = "/" + controller + "/" + action;
    $(".mdl-trava-delete").modal('hide');

    var form = new FormData();
    form.append("Id", id);
    var request = new XMLHttpRequest();
    request.onload = Reload;
    request.open("POST", url);
    request.send(form);
}


function Reload() {
    window.location.href = window.location.href;
}

