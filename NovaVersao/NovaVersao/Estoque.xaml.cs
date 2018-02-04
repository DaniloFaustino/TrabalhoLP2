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
    /// Interaction logic for Estoque.xaml
    /// </summary>
    public partial class Estoque : Window
    {
        public Estoque()
        {
            InitializeComponent();
        }

        private void BtnAdicionarProduto_Click(object sender, RoutedEventArgs e)
        {
            BtnAdicionarProduto.Visibility = System.Windows.Visibility.Collapsed;
            BtnVisualizarProduto.Visibility = System.Windows.Visibility.Collapsed;
            BtnAtualizarProduto.Visibility = System.Windows.Visibility.Collapsed;
            BlkNome.Visibility = System.Windows.Visibility.Visible;
            TxtNome.Visibility = System.Windows.Visibility.Visible;
            BlkTipo.Visibility = System.Windows.Visibility.Visible;
            TxtTipo.Visibility = System.Windows.Visibility.Visible;
            BlkQuantidade.Visibility = System.Windows.Visibility.Visible;
            TxtQuantidade.Visibility = System.Windows.Visibility.Visible;
            BtnProdutoAdd.Visibility = System.Windows.Visibility.Visible;
            BlkDesejo.Text = "ADICIONANDO PRODUTO";
        }

        private void BtnProdutoAdd_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection conex = new SqlConnection("Data Source = localhost; Initial Catalog = Restaurante; Integrated Security = SSPI;");
            SqlCommand comd = new SqlCommand();
            comd.Connection = conex;


            if (TxtNome.Text == "" || TxtTipo.Text == "" || TxtQuantidade.Text == "")
            {
                BlkErros.Text = "Formato Inválido";
            }
            else
            {
                int quantidade = int.Parse(TxtQuantidade.Text);

                comd.CommandText = Funcionalidade.AdicionarProduto();
                comd.Parameters.AddWithValue("Nome", TxtNome.Text);
                comd.Parameters.AddWithValue("Tipo", TxtTipo.Text);
                comd.Parameters.AddWithValue("Quantidade", quantidade);

                conex.Open();
                comd.ExecuteNonQuery();
                conex.Close();


                BlkErros.Text = "Atualizado";
            }
        }

        private void BtnAtualizarProduto_Click(object sender, RoutedEventArgs e)
        {
            BtnAdicionarProduto.Visibility = System.Windows.Visibility.Collapsed;
            BtnVisualizarProduto.Visibility = System.Windows.Visibility.Collapsed;
            BtnAtualizarProduto.Visibility = System.Windows.Visibility.Collapsed;
            BlkIdProduto.Visibility = System.Windows.Visibility.Visible;
            TxtIdAtt.Visibility = System.Windows.Visibility.Visible;
            BtnVerificarId.Visibility = System.Windows.Visibility.Visible;
            BlkDesejo.Text = "ATUALIZANDO PRODUTO"; 
        }

        private void BtnVerificarId_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection conex = new SqlConnection("Data Source = localhost; Initial Catalog = Restaurante; Integrated Security = SSPI;");
            SqlCommand comd = new SqlCommand();
            comd.Connection = conex;

            if (TxtIdAtt.Text == "")
            {
                BlkErros.Text = "Funcionário não encontrado";
            }
            else
            {
                int idVerifica = int.Parse(TxtIdAtt.Text);

                comd.CommandText = Funcionalidade.VerificarCodigoProdutoAtt();
                comd.Parameters.AddWithValue("Id", idVerifica);

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
                    TxtIdAtt.Text = "";
                }

                else
                {
                    BlkErros.Text = "Funcionário encontrado:";
                    BlkNomeAtt.Visibility = System.Windows.Visibility.Visible;
                    TxtNomeAtt.Visibility = System.Windows.Visibility.Visible;
                    BtnNomeAtt.Visibility = System.Windows.Visibility.Visible;
                    BlkTipoAtt.Visibility = System.Windows.Visibility.Visible;
                    TxtTipoAtt.Visibility = System.Windows.Visibility.Visible;
                    BtnTipoAtt.Visibility = System.Windows.Visibility.Visible;
                    BlkQuantidadeAtt.Visibility = System.Windows.Visibility.Visible;
                    TxtQuantidadeAtt.Visibility = System.Windows.Visibility.Visible;
                    BtnQuantidadeAtt.Visibility = System.Windows.Visibility.Visible;
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

                comd.CommandText = Funcionalidade.AtualizarProdutoNome();
                comd.Parameters.AddWithValue("Nome", TxtNomeAtt.Text);
                comd.Parameters.AddWithValue("Id", TxtIdAtt.Text);

                conex.Open();
                comd.ExecuteNonQuery();
                conex.Close();


                BlkErros.Text = "Atualizado";
                BlkNomes.Text = "";
            }
        }

        private void BtnTipoAtt_Click(object sender, RoutedEventArgs e)
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

                comd.CommandText = Funcionalidade.AtualizarProdutoTipo();
                comd.Parameters.AddWithValue("Tipo", TxtTipoAtt.Text);
                comd.Parameters.AddWithValue("Id", TxtIdAtt.Text);

                conex.Open();
                comd.ExecuteNonQuery();
                conex.Close();


                BlkErros.Text = "Atualizado";
                BlkNomes.Text = "";
            }
        }

        private void BtnQuantidadeAtt_Click(object sender, RoutedEventArgs e)
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

                int quantidade = int.Parse(TxtQuantidadeAtt.Text);

                comd.CommandText = Funcionalidade.AtualizarProdutoQuantidade();
                comd.Parameters.AddWithValue("Quantidade", quantidade);
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
