using PTC.Domain.Entities;
using PTC.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTC.Domain.Testes.Entities
{
    public class DocumentoTestes
    {
        [Fact]
        public void FormatarDocumentoTeste()
        {
            string numero = "448.724.598-22";
            var documento = new Documento(numero);
            Assert.Equal(EnumTipoDocumento.CPF.ToString(), documento.EnumTipoDocumento.ToString());
        }
    }
}
