using Xunit;
using PTC.Domain.Entities;
using PTC.Domain.Enums;

namespace PTC.Test.Tests.Entities
{
    public class ProprietarioTeste
    {

        //[Theory]
        //[InlineData("44.436.599/0001-86")]
        //[InlineData("44.436.599/0001-32")]
        //[InlineData("44.436.3220001-86")]
        //[InlineData("44436.455/000186")]
        //[InlineData("44.436.277000186")]
        //public void TestaProprietarioDefiniTipoPessoaJuririca(string documento)
        //{
        //    Proprietario proprietario = new Proprietario()
        //    {
        //        Documento = documento
        //    };

        //    EnumTipoPessoa tipoPessoa = proprietario.DefiniTipoPessoa();

        //    Assert.Equal(EnumTipoPessoa.PessoaJuridica, tipoPessoa);
            
        //}


        //[Theory]
        //[InlineData("448.724.598-22")]
        //[InlineData("448.724598-22")]
        //[InlineData("448.72459822")]
        //[InlineData("44872459822")]
        //public void TestaProprietarioDefiniTipoPessoaFisica(string documento)
        //{
        //    Proprietario proprietario = new Proprietario()
        //    {
        //        Documento = documento
        //    };

        //    EnumTipoPessoa tipoPessoa = proprietario.DefiniTipoPessoa();

        //    Assert.Equal(EnumTipoPessoa.PessoaFisica, tipoPessoa);

        //}


        //[Theory]
        //[InlineData("448724")]
        //[InlineData("")]
        //[InlineData("3213131321")]
        //[InlineData("448.724.99")]
        //public void TestaProprietarioDefiniTipoNaoIdentificado(string documento)
        //{
        //    Proprietario proprietario = new Proprietario()
        //    {
        //        Documento = documento
        //    };

        //    EnumTipoPessoa tipoPessoa = proprietario.DefiniTipoPessoa();

        //    Assert.Equal(EnumTipoPessoa.NaoIdentificado, tipoPessoa);

        //}
    }
}
