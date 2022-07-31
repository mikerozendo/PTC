namespace PTC.Application.Dtos
{
    public class MensagemViewModel
    {
        public string Controller { get; set; }
        public string ControllerAction { get; set; }
        public string Mensagem { get; set; }
        public string Titulo { get; set; }
        public bool StatusSucesso { get; set; }
        public bool Trava { get; set; }
        public int ModelId { get; set; }
    }
}
