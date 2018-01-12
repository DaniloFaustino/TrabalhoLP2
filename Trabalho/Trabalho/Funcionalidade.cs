using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho
{
    public static class Funcionalidade
    {
        public static string Login()
        {
            return "SELECT Id FROM GERENTE WHERE CÓDIGO = @Codigo AND SENHA = @Senha";
        }
    }
}
