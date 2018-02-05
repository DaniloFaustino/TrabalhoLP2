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
    /// Interaction logic for VIsualizarGerente.xaml
    /// </summary>
    public partial class VIsualizarGerente : Window
    {
        public VIsualizarGerente()
        {
            InitializeComponent();
        }

        private void BtnVisuTodos_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection conex = new SqlConnection("Data Source = localhost; Initial Catalog = Restaurante; Integrated Security = SSPI;");
            SqlCommand comd = new SqlCommand();
            comd.Connection = conex;

            comd.CommandText = Funcionalidade.TamanhoTabelaGerente();

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

            comd.CommandText = Funcionalidade.VisualizarTodosGerentes();

            comd.Connection.Open();
            SqlDataReader leitor = comd.ExecuteReader();
            string[] codigo = new string[total];
            if (leitor.HasRows)
            { 
                while (leitor.Read())
                {
                    codigo[i] = leitor.GetString(0);
                    i++;
                }
            }
            reader.Close();
            comd.Connection.Close();

            for (int a = 0; a < total; a++)
            {
                LstTodos.Items.Add(codigo[a]);
            }

        }

        private void BtnVisualizarTurno_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection conex = new SqlConnection("Data Source = localhost; Initial Catalog = Restaurante; Integrated Security = SSPI;");
            SqlCommand comd = new SqlCommand();
            comd.Connection = conex;

            comd.CommandText = Funcionalidade.TamanhoTabelaGerenteTurno();
            comd.Parameters.AddWithValue("Turno", TxtTurno.Text);

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

            comd.CommandText = Funcionalidade.VisualizarTurnosGerentes();
            comd.Parameters.AddWithValue("Turno", TxtTurno.Text);

            comd.Connection.Open();
            SqlDataReader leitor = comd.ExecuteReader();
            string[] codigo = new string[total];
            if (leitor.HasRows)
            {
                while (leitor.Read())
                {
                    codigo[i] = leitor.GetString(0);
                    i++;
                }
            }
            reader.Close();
            comd.Connection.Close();

            for (int a = 0; a < total; a++)
            {
                LstTodos.Items.Add(codigo[a]);
            }
        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
