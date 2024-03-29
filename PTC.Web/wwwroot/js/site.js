﻿//JS helper

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
                if (j.toString().toLowerCase().includes("sucesso")) {
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
    $(".modal-mensagem").modal('hide');
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

function Reload() {
    window.location.href = window.location.href;
}

function AbrirModalRedirect(target) {
    debugger;
    console.log(target);
    let targetId = $(target).attr("id");
    $("#" + targetId).modal('show');
    $(".modal-backdrop").remove();
}

function GerarNotificacao(url, modalId) {
    $(`#${modalId}`).load(url.replace(/amp%3B/g, ""));
    $(`#${modalId}`).modal({ backdrop: 'static', keyboard: true }).show();
}

function CarregarPartialView(url, elementHandler) {
    $(`#${elementHandler}`).html('');
    $(`#${elementHandler}`).load(url.replace(/amp%3B/g, ""));
}

function AbrirModal(targetId) {
    console.log(targetId);
    $("#" + targetId).modal('show');
    $(".modal-backdrop").remove();
}