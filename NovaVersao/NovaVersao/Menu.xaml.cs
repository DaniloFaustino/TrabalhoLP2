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

namespace NovaVersao
{
    /// <summary>
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void BtnGerente_Click(object sender, RoutedEventArgs e)
        {
            Gerente ger = new Gerente();
            ger.ShowDialog();
        }

        private void BtnFuncionario_Click(object sender, RoutedEventArgs e)
        {
            Funcionario fun = new Funcionario();
            fun.ShowDialog();
        }

        private void BtnEstoque_Click(object sender, RoutedEventArgs e)
        {
            Estoque est = new Estoque();
            est.ShowDialog();
        }

        private void BtnFaturamento_Click(object sender, RoutedEventArgs e)
        {
            Faturamento fat = new Faturamento();
            fat.ShowDialog();
        }
    }
}
