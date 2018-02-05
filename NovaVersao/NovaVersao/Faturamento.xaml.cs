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
    /// Interaction logic for Faturamento.xaml
    /// </summary>
    public partial class Faturamento : Window
    {
        public Faturamento()
        {
            InitializeComponent();
        }

        private void BtnAdicionarProduto_Click(object sender, RoutedEventArgs e)
        {
            BtnAdicionarConta.Visibility = System.Windows.Visibility.Collapsed;
            BtnVisualizarConta.Visibility = System.Windows.Visibility.Collapsed;
            BtnAtualizarConta.Visibility = System.Windows.Visibility.Collapsed;
            BlkDia.Visibility = System.Windows.Visibility.Visible;
            TxtDia.Visibility = System.Windows.Visibility.Visible;
            TxtMes.Visibility = System.Windows.Visibility.Visible;
            TxtAno.Visibility = System.Windows.Visibility.Visible;
            BlkValor.Visibility = System.Windows.Visibility.Visible;
            TxtValor.Visibility = System.Windows.Visibility.Visible;
            BlkValor.Visibility = System.Windows.Visibility.Visible;
            BlkFuncionario.Visibility = System.Windows.Visibility.Visible;
            TxtFuncionario.Visibility = System.Windows.Visibility.Visible;
            BtnContaAdd.Visibility = System.Windows.Visibility.Visible;
            BlkDesejo.Text = "ADICIONANDO CONTA";
        }

        private void BtnProdutoAdd_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection conex = new SqlConnection("Data Source = localhost; Initial Catalog = Restaurante; Integrated Security = SSPI;");
            SqlCommand comd = new SqlCommand();
            comd.Connection = conex;


            if (TxtDia.Text == "" || TxtMes.Text == "" || TxtAno.Text == "" || TxtValor.Text == "" || TxtFuncionario.Text == "")
            {
                BlkErros.Text = "Formato Inválido";
            }
            else
            {
                int valor = int.Parse(TxtValor.Text);

                comd.CommandText = Funcionalidade.AdicionarConta();
                comd.Parameters.AddWithValue("Valor", valor);
                comd.Parameters.AddWithValue("Funcionario", TxtFuncionario.Text);
                comd.Parameters.AddWithValue("Dia", TxtDia.Text);
                comd.Parameters.AddWithValue("Mes", TxtMes.Text);
                comd.Parameters.AddWithValue("Ano", TxtAno.Text);

                conex.Open();
                comd.ExecuteNonQuery();
                conex.Close();


                BlkErros.Text = "Atualizado";
            }
        }

        private void BtnAtualizarProduto_Click(object sender, RoutedEventArgs e)
        {
            BtnAdicionarConta.Visibility = System.Windows.Visibility.Collapsed;
            BtnVisualizarConta.Visibility = System.Windows.Visibility.Collapsed;
            BtnAtualizarConta.Visibility = System.Windows.Visibility.Collapsed;
            BlkIdConta.Visibility = System.Windows.Visibility.Visible;
            TxtIdAtt.Visibility = System.Windows.Visibility.Visible;
            BtnVerificarId.Visibility = System.Windows.Visibility.Visible;
            BlkDesejo.Text = "ATUALIZANDO CONTA";
        }

        private void BtnVerificarId_Click(object sender, RoutedEventArgs e)
        {

            SqlConnection conex = new SqlConnection("Data Source = localhost; Initial Catalog = Restaurante; Integrated Security = SSPI;");
            SqlCommand comd = new SqlCommand();
            comd.Connection = conex;

            if (TxtIdAtt.Text == "")
            {
                BlkErros.Text = "Conta não encontrada";
            }
            else
            {
                comd.CommandText = Funcionalidade.VerificarCodigoFaturamento();
                comd.Parameters.AddWithValue("Codigo", TxtIdAtt.Text);

                comd.Connection.Open();
                SqlDataReader reader = comd.ExecuteReader();
                int id = 0;
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        id = reader.GetInt32(0);
                    }
                }
                reader.Close();
                comd.Connection.Close();

                if (id == 0)
                {
                    BlkErros.Text = "Conta não encontrada";
                    TxtIdAtt.Text = "";
                }
                else
                {
                    BlkErros.Text = "Conta encontrada:";
                    BlkDataAtt.Visibility = System.Windows.Visibility.Visible;
                    TxtDiaAtt.Visibility = System.Windows.Visibility.Visible;
                    TxtMesAtt.Visibility = System.Windows.Visibility.Visible;
                    TxtAnoAtt.Visibility = System.Windows.Visibility.Visible;
                    BtnDataAtt.Visibility = System.Windows.Visibility.Visible;
                    BlkValorAtt.Visibility = System.Windows.Visibility.Visible;
                    TxtValorAtt.Visibility = System.Windows.Visibility.Visible;
                    BtnValorAtt.Visibility = System.Windows.Visibility.Visible;
                    BlkFuncionarioAtt.Visibility = System.Windows.Visibility.Visible;
                    TxtFuncionarioAtt.Visibility = System.Windows.Visibility.Visible;
                    BtnFuncionarioAtt.Visibility = System.Windows.Visibility.Visible;
                    BlkNomes.Text = id.ToString();  
                }
            }
        }
        private void BtnDataAtt_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection conex = new SqlConnection("Data Source = localhost; Initial Catalog = Restaurante; Integrated Security = SSPI;");
            SqlCommand comd = new SqlCommand();
            comd.Connection = conex;

            if (TxtDiaAtt.Text == "" || TxtMesAtt.Text == "" || TxtAnoAtt.Text == "")
            {
                BlkErros.Text = "Formato inválido";
            }
            else
            {
                BlkErros.Text = "";

                comd.CommandText = Funcionalidade.AtualizarContaData();
                comd.Parameters.AddWithValue("Dia", TxtDiaAtt.Text);
                comd.Parameters.AddWithValue("Mes", TxtMesAtt.Text);
                comd.Parameters.AddWithValue("Ano", TxtAnoAtt.Text);
                comd.Parameters.AddWithValue("Id", TxtIdAtt.Text);

                conex.Open();
                comd.ExecuteNonQuery();
                conex.Close();


                BlkErros.Text = "Atualizado";
                BlkNomes.Text = "";
            }
        }

        private void BtnValorAtt_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection conex = new SqlConnection("Data Source = localhost; Initial Catalog = Restaurante; Integrated Security = SSPI;");
            SqlCommand comd = new SqlCommand();
            comd.Connection = conex;

            if (TxtValorAtt.Text == "")
            {
                BlkErros.Text = "Formato inválido";
            }
            else
            {
                BlkErros.Text = "";

                int valorAtt = int.Parse(TxtValorAtt.Text);

                comd.CommandText = Funcionalidade.AtualizarContaValor();
                comd.Parameters.AddWithValue("Valor", valorAtt);
                comd.Parameters.AddWithValue("Id", TxtIdAtt.Text);

                conex.Open();
                comd.ExecuteNonQuery();
                conex.Close();


                BlkErros.Text = "Atualizado";
                BlkNomes.Text = "";
            }
        }

        private void BtnFuncionarioAtt_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection conex = new SqlConnection("Data Source = localhost; Initial Catalog = Restaurante; Integrated Security = SSPI;");
            SqlCommand comd = new SqlCommand();
            comd.Connection = conex;

            if (TxtFuncionarioAtt.Text == "")
            {
                BlkErros.Text = "Formato inválido";
            }
            else
            {
                BlkErros.Text = "";

                comd.CommandText = Funcionalidade.AtualizarContaFuncionario();
                comd.Parameters.AddWithValue("Funcionario", TxtFuncionarioAtt.Text);
                comd.Parameters.AddWithValue("Id", TxtIdAtt.Text);

                conex.Open();
                comd.ExecuteNonQuery();
                conex.Close();


                BlkErros.Text = "Atualizado";
                BlkNomes.Text = "";
            }
        }
    }
}
