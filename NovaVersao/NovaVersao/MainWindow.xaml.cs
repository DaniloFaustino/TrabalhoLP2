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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;

namespace NovaVersao
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TxtUser_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection conex = new SqlConnection("Data Source = localhost; Initial Catalog = Restaurante; Integrated Security = SSPI;");
            SqlCommand comd = new SqlCommand();
            comd.Connection = conex;

            if (TxtUser.Text == "" || PswSenha.Password == "")
            {
                TxtErro.Text = "Informações Inválidas";
                TxtUser.Text = "";
                PswSenha.Password = "";
            }
            else
            {
                comd.CommandText = Funcionalidade.Login();
                comd.Parameters.AddWithValue("Codigo", TxtUser.Text);
                comd.Parameters.AddWithValue("Senha", PswSenha.Password);

                comd.Connection.Open();
                SqlDataReader reader = comd.ExecuteReader();
                int s = 0;
                if (reader.HasRows)
                {
                    reader.Read();
                    s = reader.GetInt32(0);
                }
                reader.Close();
                comd.Connection.Close();

                if (s == 0)
                {
                    TxtErro.Text = "Informações Inválidas";
                    TxtUser.Text = "";
                    PswSenha.Password = "";
                }
                else
                {
                    Menu novo = new Menu();
                    novo.ShowDialog();
                }
            }

        }
    }
}
