using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovaVersao
{
    public static class Funcionalidade
    {
        public static string Login()
        {
            return "SELECT Id FROM GERENTE WHERE CÓDIGO = @Codigo AND SENHA = @Senha";
        }
        public static string VerificarCodigo()
        {
            return "SELECT Id, Nome FROM FUNCIONÁRIO WHERE CÓDIGO = @Codigo";
        }
        public static string RegistrarGerente()
        {
            return string.Format("INSERT INTO GERENTE (Código, Senha, Nome) VALUES (@Código, @Senha, @Nome);" + "UPDATE FUNCIONÁRIO SET FUNCAO = 'Gerente' WHERE CÓDIGO = @Código");
        }
    }
}
