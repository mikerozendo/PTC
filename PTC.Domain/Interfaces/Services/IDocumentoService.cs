namespace PTC.Domain.Interfaces.Services
{
    public interface IDocumentoService
    {
        bool ValidarCnpj(string cnpj);
        bool ValidarCPF(string cpf);
        bool ValidarDocumento(string documento);
    }
}
