namespace PTC.Infrastructure.Data.Base
{
    public class Parametro<TDataType> : Parametro
    {
        public Parametro(string nome, TDataType valor)
        {
            Nome = nome;
            if (typeof(TDataType) == typeof(string))
                Valor = valor == null ? string.Empty : valor.ToString().Trim();
            else
                Valor = valor;
        }
    }
}
