﻿using System;
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
            return "SELECT Id, Nome FROM FUNCIONARIO WHERE CÓDIGO = @Codigo";
        }

        public static string RegistrarGerente()
        {
            return string.Format("INSERT INTO GERENTE (Código, Senha, Nome) VALUES (@Código, @Senha, @Nome);" + "UPDATE FUNCIONARIO SET FUNCAO = 'Gerente' WHERE CÓDIGO = @Código");
        }

        public static string VerificarCodigoAtualizacaoGerente()
        {
            return "SELECT Id, Nome FROM GERENTE WHERE CÓDIGO = @Codigo";
        }

        public static string VerificarSenhaAtualizacaoGerente()
        {
            return "SELECT Senha FROM GERENTE WHERE CÓDIGO = @Codigo";
        }

        public static string AtualizarGerente()
        {
            return "UPDATE GERENTE SET SENHA = @Senha WHERE CÓDIGO = @Código";
        }

        public static string AdicionarFuncionario()
        {
            return "INSERT INTO FUNCIONARIO (Código, Nome, Inicio, Status, Funcao, Salario, Turno) VALUES (@Codigo, @Nome, @Inicio, @Status, @Funcao, @Salario, @Turno)";
        }

        public static string AtualizarFuncionarioNome()
        {
            return "UPDATE FUNCIONARIO SET NOME = @Nome WHERE CÓDIGO = @Codigo";
        }

        public static string AtualizarFuncionarioTurno()
        {
            return "UPDATE FUNCIONARIO SET TURNO = @Turno WHERE CÓDIGO = @Codigo";
        }

        public static string AtualizarFuncionarioFuncao()
        {
            return "UPDATE FUNCIONARIO SET FUNCAO = @Funcao WHERE CÓDIGO = @Codigo";
        }

        public static string AtualizarFuncionarioSalario()
        {
            return "UPDATE FUNCIONARIO SET SALARIO = @Salario WHERE CÓDIGO = @Codigo";
        }
        public static string AdicionarProduto()
        {
            return "INSERT INTO ESTOQUE (Nome, Tipo, Quantidade) VALUES (@Nome, @Tipo, @Quantidade)";
        }
        public static string AtualizarProdutoNome()
        {
            return "UPDATE ESTOQUE SET NOME = @Nome WHERE Id = @Id";
        }

        public static string AtualizarProdutoTipo()
        {
            return "UPDATE ESTOQUE SET TIPO = @Tipo WHERE Id = @Id";
        }
        public static string AtualizarProdutoQuantidade()
        {
            return "UPDATE ESTOQUE SET QUANTIDADE = @Quantidade WHERE Id = @Id";
        }
        public static string VerificarCodigoProdutoAtt()
        {
            return "SELECT Id, Nome FROM ESTOQUE WHERE Id = @Id";
        }
        public static string AdicionarConta()
        {
            return "INSERT INTO FATURAMENTO (Valor, Funcionario, Dia, Mês, Ano) VALUES (@Valor, @Funcionario, @Dia, @Mes, @Ano)";
        }
        public static string VerificarCodigoFaturamento()
        {
            return "SELECT Id FROM FATURAMENTO WHERE Id = @Codigo";
        }
        public static string AtualizarContaData()
        {
            return "UPDATE FATURAMENTO SET Dia = @Dia, Mês = @Mes, Ano = @Ano WHERE Id = @Id";
        }
        public static string AtualizarContaValor()
        {
            return "UPDATE FATURAMENTO SET VALOR = @Valor WHERE Id = @Id";
        }
        public static string AtualizarContaFuncionario()
        {
            return "UPDATE FATURAMENTO SET Funcionario = @Funcionario WHERE Id = @Id";
        }
        public static string VisualizarTodosGerentes()
        {
            return "SELECT Nome FROM Gerente";
        }
        public static string TamanhoTabelaGerente()
        {
            return "SELECT COUNT(Código) FROM Gerente";
        }
        public static string TamanhoTabelaGerenteTurno()
        {
            return "SELECT COUNT(Turno) FROM FUNCIONARIO WHERE Funcao = 'Gerente'";
        }
        public static string VisualizarTurnosGerentes()
        {
            return "SELECT Nome FROM Funcionario WHERE Turno = @Turno AND Funcao = 'Gerente'";
        }
        public static string TamanhoTabelaFuncionario()
        {
            return "SELECT COUNT(Código) FROM Funcionario";
        }
        public static string VisualizarTodosFuncionarios()
        {
            return "SELECT Nome, Funcao, Código FROM Funcionario";
        }
        public static string TamanhoTabelaFuncionarioFuncao()
        {
            return "SELECT COUNT(Id) FROM Funcionario WHERE Funcao = @Funcao";
        }
        public static string VisualizarFuncaoFuncionario()
        {
            return "SELECT Nome, Código FROM Funcionario WHERE Funcao = @Funcao";
        }
        public static string TamanhoTabelaEstoque()
        {
            return "SELECT COUNT(Id) FROM Estoque";
        }
        public static string VisualizarTodoEstoque()
        {
            return "SELECT Id, Nome, Quantidade FROM Estoque";
        }
        public static string TamanhoTabelaEstoqueTipo()
        {
            return "SELECT COUNT(Id) FROM ESTOQUE WHERE Tipo = @Tipo";
        }
        public static string VisualizarTipoEstoque()
        {
            return "SELECT Id, Nome, Quantidade FROM Estoque WHERE Tipo = @Tipo";
        }
        public static string VisualizarConta()
        {
            return "SELECT Valor, Funcionario, Dia, Mês, Ano FROM Faturamento";
        }
        public static string VisualizarSoma()
        {
            return "SELECT SUM(Valor) FROM Faturamento WHERE Mês = @Mês AND Ano = @Ano GROUP BY Valor";
        }
    }
}
