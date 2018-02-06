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
    /// Interaction logic for VisualizarFaturamento.xaml
    /// </summary>
    public partial class VisualizarFaturamento : Window
    {
        public VisualizarFaturamento()
        {
            InitializeComponent();
        }

        private void BtnId_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection conex = new SqlConnection("Data Source = localhost; Initial Catalog = Restaurante; Integrated Security = SSPI;");
            SqlCommand comd = new SqlCommand();
            comd.Connection = conex;

            int idi = int.Parse(TxtId.Text);

            comd.CommandText = Funcionalidade.VisualizarConta();
            comd.Parameters.AddWithValue("Id", idi); 

            int i = 0;

            comd.Connection.Open();
            SqlDataReader leitor = comd.ExecuteReader();
            int valor = 0;
            string codi = "";
            string dia = "";
            string mes = "";
            string ano = ""; 
            if (leitor.HasRows)
            {
                while (leitor.Read())
                {
                    valor = leitor.GetInt32(0);
                    codi = leitor.GetString(1);
                    dia = leitor.GetString(2);
                    mes = leitor.GetString(3);
                    ano = leitor.GetString(4); 
                    i++;
                }
            }
            leitor.Close();
            comd.Connection.Close();

            
                LstValor.Items.Add(valor);
                LstFuncio.Items.Add(codi);
                LstDia.Items.Add(dia);
                LstMes.Items.Add(mes);
                LstAno.Items.Add(ano);
            
        }

        private void LstDia_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void LstAno_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TxtSoma_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection conex = new SqlConnection("Data Source = localhost; Initial Catalog = Restaurante; Integrated Security = SSPI;");
            SqlCommand comd = new SqlCommand();
            comd.Connection = conex;

            comd.CommandText = Funcionalidade.VisualizarSoma();
            comd.Parameters.AddWithValue("Mês", TxtMes.Text);
            comd.Parameters.AddWithValue("Ano", TxtAno.Text);


            comd.Connection.Open();

            try
            {
                SqlDataReader leitor = comd.ExecuteReader();
            

                int valor = 0;
           
                if (leitor.HasRows)
                {
                    while (leitor.Read())
                    {
                        valor = leitor.GetInt32(0);
                    }
                }
                leitor.Close();
                comd.Connection.Close();
            

                LstLucro.Items.Add(valor);

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
    }
}
