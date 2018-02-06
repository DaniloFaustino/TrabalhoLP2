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
    /// Interaction logic for Funcionario.xaml
    /// </summary>
    public partial class Funcionario : Window
    {
        public Funcionario()
        {
            InitializeComponent();
        }

        private void BtnAdicionarFun_Click(object sender, RoutedEventArgs e)
        {
            BtnAdicionarFun.Visibility = System.Windows.Visibility.Collapsed;
            BtnVisualizarFun.Visibility = System.Windows.Visibility.Collapsed;
            BtnAtualizarFun.Visibility = System.Windows.Visibility.Collapsed;
            BlkCodigoAdd.Visibility = System.Windows.Visibility.Visible;
            BlkNomeAdd.Visibility = System.Windows.Visibility.Visible;
            BlkFuncaoAdd.Visibility = System.Windows.Visibility.Visible;
            BlkTurnoAdd.Visibility = System.Windows.Visibility.Visible;
            BlkSalarioAdd.Visibility = System.Windows.Visibility.Visible;
            TxtCodigoAdd.Visibility = System.Windows.Visibility.Visible;
            TxtNomeAdd.Visibility = System.Windows.Visibility.Visible;
            TxtFuncaoAdd.Visibility = System.Windows.Visibility.Visible;
            TxtTurnoAdd.Visibility = System.Windows.Visibility.Visible;
            TxtSalarioAdd.Visibility = System.Windows.Visibility.Visible;
            BtnFuncioAdd.Visibility = System.Windows.Visibility.Visible;
            BlkDesejo.Text = "ADICIONANDO FUNCIONÁRIO";
        }

        private void BtnFuncioAdd_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection conex = new SqlConnection("Data Source = localhost; Initial Catalog = Restaurante; Integrated Security = SSPI;");
            SqlCommand comd = new SqlCommand();
            comd.Connection = conex;

            
            if (TxtCodigoAdd.Text == "" || TxtNomeAdd.Text == "" || TxtFuncaoAdd.Text == "" || TxtTurnoAdd.Text == "" || TxtSalarioAdd.Text == "")
            {
                BlkErros.Text = "Formato Inválido";
            }

            else
            {
                BlkErros.Text = "";

                int sal = int.Parse(TxtSalarioAdd.Text);
                string data = DateTime.Now.ToString("dd/MM/yyyy");

                comd.CommandText = Funcionalidade.AdicionarFuncionario();
                comd.Parameters.AddWithValue("Codigo", TxtCodigoAdd.Text);
                comd.Parameters.AddWithValue("Nome", TxtNomeAdd.Text);
                comd.Parameters.AddWithValue("Inicio", "08/10/2017");
                comd.Parameters.AddWithValue("Status", '1');
                comd.Parameters.AddWithValue("Funcao", TxtFuncaoAdd.Text);
                comd.Parameters.AddWithValue("Salario", data);
                comd.Parameters.AddWithValue("Turno", TxtTurnoAdd.Text);


                conex.Open();
                comd.ExecuteNonQuery();
                conex.Close();


                BlkErros.Text = "Atualizado";
             }
           
        }

        private void BtnAtualizarFun_Click(object sender, RoutedEventArgs e)
        {
            BtnAdicionarFun.Visibility = System.Windows.Visibility.Collapsed;
            BtnVisualizarFun.Visibility = System.Windows.Visibility.Collapsed;
            BtnAtualizarFun.Visibility = System.Windows.Visibility.Collapsed;
            BlkCodigoAtt.Visibility = System.Windows.Visibility.Visible;
            TxtCodigoAtt.Visibility = System.Windows.Visibility.Visible;
            BtnVerificarAtt.Visibility = System.Windows.Visibility.Visible;
        }

        private void BtnVerificarAtt_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection conex = new SqlConnection("Data Source = localhost; Initial Catalog = Restaurante; Integrated Security = SSPI;");
            SqlCommand comd = new SqlCommand();
            comd.Connection = conex;

            if (TxtCodigoAtt.Text == "")
            {
                BlkErros.Text = "Funcionário não encontrado";
            }
            else
            {
                comd.CommandText = Funcionalidade.VerificarCodigo();
                comd.Parameters.AddWithValue("Codigo", TxtCodigoAtt.Text);

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
                    BlkErros.Text = "Funcionário não encontrado";
                    TxtCodigoAtt.Text = "";
                }
                else
                {
                    BlkErros.Text = "Funcionário encontrado:";
                    BlkNomeAtt.Visibility = System.Windows.Visibility.Visible;
                    TxtNomeAtt.Visibility = System.Windows.Visibility.Visible;
                    BtnNomeAtt.Visibility = System.Windows.Visibility.Visible;
                    BlkTurnoAtt.Visibility = System.Windows.Visibility.Visible;
                    TxtTurnoAtt.Visibility = System.Windows.Visibility.Visible;
                    BtnTurnoAtt.Visibility = System.Windows.Visibility.Visible;
                    BlkFuncaoAtt.Visibility = System.Windows.Visibility.Visible;
                    TxtFuncaoAtt.Visibility = System.Windows.Visibility.Visible;
                    BtnFuncaoAtt.Visibility = System.Windows.Visibility.Visible;
                    BlkSalarioAtt.Visibility = System.Windows.Visibility.Visible;
                    TxtSalarioAtt.Visibility = System.Windows.Visibility.Visible;
                    BtnSalarioAtt.Visibility = System.Windows.Visibility.Visible;
                    BlkNomes.Text = nome;
                }
            }
        }

        private void BtnNomeAtt_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection conex = new SqlConnection("Data Source = localhost; Initial Catalog = Restaurante; Integrated Security = SSPI;");
            SqlCommand comd = new SqlCommand();
            comd.Connection = conex;

            if (TxtNomeAtt.Text == "")
            {
                BlkErros.Text = "Formato inválido";
            }
            else
            {
                BlkErros.Text = "";

                comd.CommandText = Funcionalidade.AtualizarFuncionarioNome();
                comd.Parameters.AddWithValue("Nome", TxtNomeAtt.Text);
                comd.Parameters.AddWithValue("Codigo", TxtCodigoAtt.Text);

                conex.Open();
                comd.ExecuteNonQuery();
                conex.Close();


                BlkErros.Text = "Atualizado";
                BlkNomes.Text = "";
            }

            
        }

        private void BtnTurnoAtt_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection conex = new SqlConnection("Data Source = localhost; Initial Catalog = Restaurante; Integrated Security = SSPI;");
            SqlCommand comd = new SqlCommand();
            comd.Connection = conex;

            if (TxtTurnoAtt.Text == "")
            {
                BlkErros.Text = "Formato inválido";
            }
            else
            {
                BlkErros.Text = "";

                comd.CommandText = Funcionalidade.AtualizarFuncionarioTurno();
                comd.Parameters.AddWithValue("Turno", TxtTurnoAtt.Text);
                comd.Parameters.AddWithValue("Codigo", TxtCodigoAtt.Text);

                conex.Open();
                comd.ExecuteNonQuery();
                conex.Close();


                BlkErros.Text = "Atualizado";
                BlkNomes.Text = "";
            }

            
        }

        private void BtnFuncaoAtt_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection conex = new SqlConnection("Data Source = localhost; Initial Catalog = Restaurante; Integrated Security = SSPI;");
            SqlCommand comd = new SqlCommand();
            comd.Connection = conex;

            if (TxtFuncaoAtt.Text == "")
            {
                BlkErros.Text = "Formato inválido";
            }
            else
            {
                BlkErros.Text = "";

                comd.CommandText = Funcionalidade.AtualizarFuncionarioFuncao();
                comd.Parameters.AddWithValue("Funcao", TxtFuncaoAtt.Text);
                comd.Parameters.AddWithValue("Codigo", TxtCodigoAtt.Text);

                conex.Open();
                comd.ExecuteNonQuery();
                conex.Close();


                BlkErros.Text = "Atualizado";
                BlkNomes.Text = "";
            }

            
        }

        private void BtnSalarioAtt_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection conex = new SqlConnection("Data Source = localhost; Initial Catalog = Restaurante; Integrated Security = SSPI;");
            SqlCommand comd = new SqlCommand();
            comd.Connection = conex;

            int sal = int.Parse(TxtSalarioAtt.Text);

            if (TxtSalarioAtt.Text == "")
            {
                BlkErros.Text = "Formato inválido";
            }
            else
            {
                BlkErros.Text = "";

               
                comd.CommandText = Funcionalidade.AtualizarFuncionarioSalario();
                comd.Parameters.AddWithValue("Salario", sal);
                comd.Parameters.AddWithValue("Codigo", TxtCodigoAtt.Text);

                conex.Open();
                comd.ExecuteNonQuery();
                conex.Close();


                BlkErros.Text = "Atualizado";
                BlkNomes.Text = "";
            }           
        }

        private void BtnVisualizarFun_Click(object sender, RoutedEventArgs e)
        {
            VisualizarFuncionario visu = new VisualizarFuncionario();
            visu.ShowDialog();
        }
    }
}
