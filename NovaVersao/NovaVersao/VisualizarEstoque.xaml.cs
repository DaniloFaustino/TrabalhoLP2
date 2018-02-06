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
    /// Interaction logic for VisualizarEstoque.xaml
    /// </summary>
    public partial class VisualizarEstoque : Window
    {
        public VisualizarEstoque()
        {
            InitializeComponent();
        }

        private void BtnTodos_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection conex = new SqlConnection("Data Source = localhost; Initial Catalog = Restaurante; Integrated Security = SSPI;");
            SqlCommand comd = new SqlCommand();
            comd.Connection = conex;

            comd.CommandText = Funcionalidade.TamanhoTabelaEstoque();

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

            comd.CommandText = Funcionalidade.VisualizarTodoEstoque();

            comd.Connection.Open();
            SqlDataReader leitor = comd.ExecuteReader();
            int[] id = new int[total];
            string[] nome = new string[total];
            int[] qtd = new int[total];
            if (leitor.HasRows)
            {
                while (leitor.Read())
                {
                    id[i] = leitor.GetInt32(0);
                    nome[i] = leitor.GetString(1);
                    qtd[i] = leitor.GetInt32(2);
                    i++;
                }
            }
            reader.Close();
            comd.Connection.Close();

            for (int a = 0; a < total; a++)
            {
                LstId.Items.Add(id[a]);
                LstNome.Items.Add(nome[a]);
                LstQtd.Items.Add(qtd[a]);
            }
        }

        private void BtnTipo_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection conex = new SqlConnection("Data Source = localhost; Initial Catalog = Restaurante; Integrated Security = SSPI;");
            SqlCommand comd = new SqlCommand();
            comd.Connection = conex;

            comd.CommandText = Funcionalidade.TamanhoTabelaEstoqueTipo();
            comd.Parameters.AddWithValue("Tipo", TxtTipo.Text);



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

            comd.CommandText = Funcionalidade.VisualizarTipoEstoque();
            comd.Parameters.AddWithValue("Tipo", TxtTipo.Text);

            comd.Connection.Open();
            SqlDataReader leitor = comd.ExecuteReader();
            int[] id = new int[total];
            string[] nome = new string[total];
            int[] qtd = new int[total];
            if (leitor.HasRows)
            {
                while (leitor.Read())
                {
                    id[i] = leitor.GetInt32(0);
                    nome[i] = leitor.GetString(1);
                    qtd[i] = leitor.GetInt32(2);
                    i++;
                }
            }
            leitor.Close();
            comd.Connection.Close();

            for (int a = 0; a < total; a++)
            {
                LstId.Items.Add(id[a]);
                LstNome.Items.Add(nome[a]);
                LstQtd.Items.Add(qtd[a]);
            }
        }

    }
}

