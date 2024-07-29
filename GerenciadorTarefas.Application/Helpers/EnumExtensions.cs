using System.Reflection;
using System.ComponentModel;

namespace GerenciadorTarefas.Application.Helpers
{
    public class EnumExtensions
    {
        public static string ObterDescricaoEnum(Enum valorEnum)
        {
            if(valorEnum == null)
                throw new ArgumentNullException(nameof(valorEnum));

            FieldInfo? campo = valorEnum.GetType().GetField(valorEnum.ToString());

            if(campo == null) 
                return valorEnum.ToString();

            DescriptionAttribute? descricaoAtributo = campo.GetCustomAttribute<DescriptionAttribute>();
            return descricaoAtributo == null ? valorEnum.ToString() : descricaoAtributo.Description;
        }
    }
}
