using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.SqlClient; 

namespace NovaVersao
{
    /// <summary>
    /// Interaction logic for VisualizarFuncionario.xaml
    /// </summary>
    public partial class VisualizarFuncionario : Window
    {
        public VisualizarFuncionario()
        {
            InitializeComponent();
        }

        private void BtnVisuTodos_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection conex = new SqlConnection("Data Source = localhost; Initial Catalog = Restaurante; Integrated Security = SSPI;");
            SqlCommand comd = new SqlCommand();
            comd.Connection = conex;

            comd.CommandText = Funcionalidade.TamanhoTabelaFuncionario();

            comd.Connection.Open();
            SqlDataReader reader = comd.ExecuteReader();
            int total = 0;
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    total = reader.GetInt32(0);

                }
            }
            reader.Close();
            comd.Connection.Close();


            int i = 0;

            comd.CommandText = Funcionalidade.VisualizarTodosFuncionarios();

            comd.Connection.Open();
            SqlDataReader leitor = comd.ExecuteReader();
            string[] codigo = new string[total];
            string[] funcao = new string[total];
            string[] cod = new string[total];
            if (leitor.HasRows)
            {
                while (leitor.Read())
                {
                    codigo[i] = leitor.GetString(0);
                    funcao[i] = leitor.GetString(1);
                    cod[i] = leitor.GetString(2); 
                    i++;
                }
            }
            reader.Close();
            comd.Connection.Close();

            for (int a = 0; a < total; a++)
            {
                LstNome.Items.Add(codigo[a]);
                LstFuncao.Items.Add(funcao[a]);
                LstCodigo.Items.Add(cod[a]); 
            }
        }

        private void listBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BtnVisuFuncao_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection conex = new SqlConnection("Data Source = localhost; Initial Catalog = Restaurante; Integrated Security = SSPI;");
            SqlCommand comd = new SqlCommand();
            comd.Connection = conex;

            comd.CommandText = Funcionalidade.TamanhoTabelaFuncionarioFuncao();
            comd.Parameters.AddWithValue("Funcao", TxtFuncao.Text);



            comd.Connection.Open();
            SqlDataReader reader = comd.ExecuteReader();
            int total = 0;
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    total = reader.GetInt32(0);

                }
            }
            reader.Close();
            comd.Connection.Close();

            int i = 0;

            comd.CommandText = Funcionalidade.VisualizarFuncaoFuncionario();
            comd.Parameters.AddWithValue("Funcao", TxtFuncao.Text);

            comd.Connection.Open();
            SqlDataReader leitor = comd.ExecuteReader();
            string[] codigo = new string[total];
            string[] nome = new string[total];
            if (leitor.HasRows)
            {
                while (leitor.Read())
                {
                    nome[i] = leitor.GetString(1);
                    codigo[i] = leitor.GetString(0);
                    i++;
                }
            }
            leitor.Close();
            comd.Connection.Close();

            for (int a = 0; a < total; a++)
            {
                LstNomeFuncao.Items.Add(nome[a]);
                LstCodigo1.Items.Add(codigo[a]);
            }
        }
    }
}
