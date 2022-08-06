using Microsoft.AspNetCore.Mvc;
using PTC.Application.Dtos;

namespace PTC.WEB.Controllers
{
    public class NotificaController : Controller
    {
        //Retornando notificacoes de status
        public IActionResult RenderizarMensagemStatus([FromQuery]string action, [FromQuery]string controller, string titulo, string mensagem, bool sucesso)
        {
            MensagemViewModel model = new()
            {
                Controller = controller,
                ControllerAction = action,
                StatusSucesso = sucesso,
                Titulo = titulo,
                Mensagem = mensagem,
            };

            return PartialView("_Notificacao", model);
        }

        //Retornando trava p/ deletes
        public IActionResult RenderizarMensagemTrava([FromQuery]string action, [FromQuery]string controller, string titulo, string mensagem, bool trava, int modelId)
        {
            MensagemViewModel model = new()
            {
                Controller = controller,
                ControllerAction = action,
                Titulo = titulo,
                Mensagem = mensagem,
                Trava = trava,
                ModelId = modelId
            };

            return PartialView("_Notificacao", model);
        }
    }
}
