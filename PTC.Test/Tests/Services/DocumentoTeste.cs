using Xunit;
using PTC.Application.Services;

namespace PTC.Test.Tests.Services
{
    public class DocumentoTeste
    {
        [Theory]
        [InlineData("448.724.598-22")]
        [InlineData("44.436.599/0001-86")]
        [InlineData("44436599000186")]
        [InlineData("44872459822")]
        public void TestaDocumentosCorretos(string documento)
        {
            string validaDocumento = documento;
            DocumentoService documentoService = new DocumentoService();

            bool retorno = documentoService.ValidarDocumento(validaDocumento);

            Assert.True(retorno);
        }

        [Theory]
        [InlineData("00.000.000/0000-01")]
        [InlineData("00000000000000")]
        [InlineData("321321321321312")]
        [InlineData("447824599000182")]
        [InlineData("446.724.598-22")]
        [InlineData("00.000.000-0")]
        [InlineData("00.321.122-0")]
        public void TestaDocumentoErrados(string documento)
        {
            string validaDocumento = documento;

            DocumentoService documentoService = new DocumentoService();
            bool retorno = documentoService.ValidarDocumento(documento);

            Assert.False(retorno);
        }
    }
}
