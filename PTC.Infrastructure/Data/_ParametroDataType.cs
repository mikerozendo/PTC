using System.Data;

namespace PTC.Infrastructure.Data
{
    public class Parametro<TDataType> : Parametro
    {
        public Parametro(string nome, TDataType valor)
        {
            Nome = nome;
            //Tipo = tipo;
            if(typeof(TDataType) == typeof(string))
            {
                Valor = valor == null ? string.Empty : valor.ToString().Trim();
            }
            else
            {
                Valor = valor;
            }
        }
    }
}
