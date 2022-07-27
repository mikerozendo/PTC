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
    $('.containner-main-content').css("overflow-y", "scroll");

    document.forms[form].addEventListener('submit', (event) => {
        event.preventDefault();
        ColetarRespostaServidor(aspAction, aspController);
    });
}

function ColetarRespostaServidor(aspAction, aspController) {
    fetch(event.target.action, {
        method: 'POST',
        body: new FormData(event.target)
    }).then(function (serverPromise) {
        serverPromise.text()
            .then(function (j) {
                if (j.toString().includes("sucesso")) {
                    return ModalMensagem('Sucesso', j.toString(), aspController, aspAction, true, true);
                } else {
                    return ModalMensagem('Falha', j.toString(), aspController, aspAction, false, false);
                }
            })
            .catch(function (e) {
                return ModalMensagem('Falha', j.toString(), aspController, aspAction, false, false);
            });
    });

    return false;
}

function ModalMensagem(titulo, mensagem, controller, action, sucesso, redirect) {
    $(".mdlMensagem").html('');
    let html =
        `<div class="modal modal-mensagem" tabindex="-1" role="dialog">
      <div class="modal-dialog" role="document">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title font-bold ${(sucesso ? "text-green" : "text-red")}">${titulo}</h5>
            <span type="button" class="close span-close-modal" data-bs-dismiss="modal" aria-label="Close">
              <span aria-hidden="true">&times;</span>
            </span>
          </div>
          <div class="modal-body">
            <p>${mensagem}</p>
          </div>
          <div class="modal-footer">
            <div class="row modal-footer-row">
                <div class="col-12 text-right">`;

    if (redirect) {
        html += `<button onclick="RedirectToAction('${controller}','${action}')" type="button" class="btn btn-primary btn-success">Ok</button>`;
    } else {
        html += `<button onclick="FecharModalMensagem()" type="button" class="btn btn-primary btn-success">Ok</button>`;
    }

    html += '</div></div></div></div></div></div>';

    $(".mdlMensagem").html(html);
    $(".modal-mensagem").modal({ backdrop: 'static', keyboard: true }).show();
}

function RedirectToAction(controller, action) {
    FecharModalMensagem();
    window.location.href = "/" + controller + "/" + action
}

function FecharModalMensagem() {
    $(".modal-mesangem").modal('hide');
    $(".mdlMensagem").html('');
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
            <span type="button" class="close span-close-modal" data-bs-dismiss="modal" aria-label="Close">
              <span aria-hidden="true">&times;</span>
            </span>
          </div>
          <div class="modal-body">
            <p>${msgString}</p>
          </div>
          <div class="modal-footer">
            <div class="row modal-footer-row">
                <div class="col-6 text-left">
                    <button type="button" class="btn btn-primary btn-success" data-bs-dismiss="modal">Cancelar</button>
                </div>
                <div class="col-6 text-right">
                    <button onclick="Deletar('${controller}','${action}',${id})" type="button" class="btn btn-danger">Continuar</button>
                </div>
            </div>
          </div>
        </div>
      </div>
    </div>`;

    $(".modalContainner").html(html);
    $(".mdl-trava-delete").modal({ backdrop: 'static', keyboard: true });
}

function Deletar(controller, action, id) {
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

function ImagemEvent(pasta) {
    $("#inputImg").on('change', function (e) {
        var value = "/images/" + pasta + "/" + $("#inputImg").val().replace('C:\\fakepath\\', '');
        console.log($("#inputImg").length);
        $("#caminhoImagem").val(value);
    });

    $("#btnImgUpload").on('click', function (e) {
        $("#inputImg").click();
        return false;
    });
}

function MontarSelect(action, controller, element, binder, btnAdicionar, btnAdicionarClass, dataTarget, Label) {
    fetch(window.location.origin + '/' + controller + '/' + action, {
        headers: {
            'Accept': 'application/json'
        }
    }).then(data => {
        data.json().then(value => {
            let select =
                `
                    <div class="row">
                        <div class="col-6 text-left">
                            <label class="lbl-inputs" for="${binder}">${Label}</label>
                        </div>
                `;
            if (btnAdicionar) {
                select += '<div class="col-6 text-right"><button type="button" onclick="AbrirModalRedirect(' + dataTarget + ')" class="btn btn-success btn-sm ' + btnAdicionarClass + '" data-toggle="modal" data-target="#' + dataTarget + '">Novo</button></div>';
            }

            select += '</div><select name="' + binder + '" id = "' + binder + '" class="form-control form-select" style="text-align:center">';
            if (value.length >= 0) {
                select += '<option value="none">- selecione -</option >';
                for (var i = 0; i < value.length; i++) {
                    select += '<option value="' + value[i].id + '">' + value[i].nome + '</option>';
                }
                select += '</select>';
                $("#" + element).html(select);
            }
        });
    });
}

function AbrirModalRedirect(target) {
    console.log(target);
    let targetId = $(target).attr("id");
    $("#" + targetId).modal('show');
    $(".modal-backdrop").remove();
}