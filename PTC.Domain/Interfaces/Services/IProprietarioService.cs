using PTC.Domain.Entities;
using System.Collections.Generic;

namespace PTC.Domain.Interfaces.Services
{
    public interface IProprietarioService
    {
        string Incluir(Proprietario proprietario);
        bool Existe(Proprietario proprietario);
        bool ValidarDocumento(string documento);
        bool ValidarCPF(string cpf);
        bool ValidarCnpj(string cnpj);
        IEnumerable<Proprietario> Obter();
    }
}
