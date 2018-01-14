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
    /// Interaction logic for Gerente.xaml
    /// </summary>
    public partial class Gerente : Window
    {
        public Gerente()
        {
            InitializeComponent();
        }

        private void BtnAdicionarGerente_Click(object sender, RoutedEventArgs e)
        {
            TxtCodigo.Visibility = System.Windows.Visibility.Visible; 
            BtnAdicionarGerente.Visibility = System.Windows.Visibility.Collapsed;
            BtnVerificarCodigo.Visibility = System.Windows.Visibility.Visible;
            BtnAtualizarGerente.Visibility = System.Windows.Visibility.Collapsed;
            BtnVisualizarGerente.Visibility = System.Windows.Visibility.Collapsed;
            BlkCodigoFuncionario.Visibility = System.Windows.Visibility.Visible;
            BlkDesejo.Text = "REGISTRANDO GERENTE";
        }

        private void BtnVerificarCodigo_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection conex = new SqlConnection("Data Source = localhost; Initial Catalog = Restaurante; Integrated Security = SSPI;");
            SqlCommand comd = new SqlCommand();
            comd.Connection = conex;

            if (TxtCodigo.Text == "")
            {
                BlkErrosInfos.Text = "Funcionário não encontrado";
            }
            else
            {
                comd.CommandText = Funcionalidade.VerificarCodigo();
                comd.Parameters.AddWithValue("Codigo", TxtCodigo.Text);

                comd.Connection.Open();
                SqlDataReader reader = comd.ExecuteReader();
                int id = 0;
                string nome = "";
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        id = reader.GetInt32(0);
                        nome = reader.GetString(1);
                    }
                }
                reader.Close();
                comd.Connection.Close();

                if (id == 0)
                {
                    BlkErrosInfos.Text = "Funcionário não encontrado";
                    TxtCodigo.Text = "";
                }
                else
                {
                    BlkErrosInfos.Text = "Usuário Encontrado:";
                    BlkDigiteSenha.Visibility = System.Windows.Visibility.Visible;
                    PswSenhaAcesso.Visibility = System.Windows.Visibility.Visible;
                    BtnRegistro.Visibility = System.Windows.Visibility.Visible;
                    BklNomes.Text = nome; 
                }
            }
        }

        private void BtnRegistro_Click(object sender, RoutedEventArgs e)
        {

            SqlConnection conex = new SqlConnection("Data Source = localhost; Initial Catalog = Restaurante; Integrated Security = SSPI;");
            SqlCommand comd = new SqlCommand();
            comd.Connection = conex;

            if (PswSenhaAcesso.Password == "")
            {
                BlkErrosInfos.Text = "Formato inválido";
                PswSenhaAcesso.Password = "";
            }
            else
            {
                comd.CommandText = Funcionalidade.RegistrarGerente();
                comd.Parameters.AddWithValue("Código", TxtCodigo.Text);
                comd.Parameters.AddWithValue("Senha", PswSenhaAcesso.Password);
                comd.Parameters.AddWithValue("Nome", BklNomes.Text);
            }

                conex.Open();
                comd.ExecuteNonQuery();
                conex.Close();

                BlkErrosInfos.Text = "Atualizado!"; 
            }
        }
    }
