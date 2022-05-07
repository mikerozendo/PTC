namespace PTC.Domain.Entities
{
    public class Imagem
    {
        public string CaminhoImagem { get; set; }
        public string Mensagem { get; set; }

        public Imagem() { }

        public Imagem(string caminho, string mensagem)
        {
            CaminhoImagem = caminho;
            Mensagem = mensagem;
        }
    }
}
