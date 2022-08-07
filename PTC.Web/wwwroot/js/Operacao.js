const baseUrlNotifica = `${window.location.origin}/Notifica/RenderizarMensagemStatus?action=${encodeURI("Index")}&controller=${encodeURI("Operacao")}`;

function factory(formMethod, urlSelectList) {
    Select2Init();
    FormEventHandler(formMethod);
    ObterMarcasSelectList(urlSelectList);
    TriggerImgImput();
}

function FormEventHandler(formMethod) {
    document.forms['formVeiculo'].addEventListener('submit', (event) => {
        event.preventDefault();
        triggerForm(formMethod);
    });
}

function triggerForm(formMethod) {

    fetch(event.target.action, {
        method: formMethod,
        body: new FormData(event.target)
    }).then(function (serverPromise) {

        if (serverPromise.status == 400) {
            serverPromise.text()
                .then(function (notificacao) {
                    let url = `${baseUrlNotifica}&titulo=${encodeURI("Falha")}&mensagem=${encodeURI(notificacao)}&sucesso=${encodeURI(false)}`;
                    GerarNotificacao(url, 'mdlMensagem');
                });
        } else {
            serverPromise.text()
                .then(function (notificacao) {

                    let url = "";

                    if (notificacao.toLowerCase.includes("sucesso")) {
                        url = `${baseUrlNotifica}&titulo=${encodeURI("Sucesso")}&mensagem=${encodeURI(notificacao)}&sucesso=${encodeURI(true)}`;
                    } else {
                        url = `${baseUrlNotifica}&titulo=${encodeURI("Falha")}&mensagem=${encodeURI(notificacao)}&sucesso=${encodeURI(false)}`;
                    }

                    GerarNotificacao(url, 'mdlMensagem');
                });
        }
    });

    return false;
}

function ObterMarcasSelectList(urlSelectList) {
    CarregarPartialView(urlSelectList, 'selectMarca');
}

function TriggerImgImput() {
    $("#btnImgUpload").on('click', function (e) {
        $("#inputImg").click();
        return false;
    });
}

function Select2Init() {
    $('select').select2({
        placeholder: "Selecione"
    });
}

            