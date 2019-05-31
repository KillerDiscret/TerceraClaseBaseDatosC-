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
using Entidades;
using Negocio;

namespace Presentacion
{
    /// <summary>
    /// Interaction logic for frmPais.xaml
    /// </summary>
    public partial class frmPais : Window
    {
        nPais paisneg = new nPais();
        ePais paisseleccionado;
        int codpais;


        public frmPais()
        {
            InitializeComponent();
            MostrarPaises();

        }
        private void MostrarPaises()
        {
            dgpaises.ItemsSource = paisneg.Listarpais();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if(txtNombre.Text!="")
            {
                MessageBox.Show(paisneg.Registrarpais(txtNombre.Text));
                MostrarPaises();
            }
            else
            {
                MessageBox.Show("debe ingresar un nombre");
            }
        }

        private void dgpaises_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            paisseleccionado = dgpaises.SelectedItem as ePais;
            if(paisseleccionado!=null)
            {
                codpais = paisseleccionado.Idpais;
                txtNombre.Text = paisseleccionado.Nombrepais;
                
            }
        }

        private void button_Copy_Click(object sender, RoutedEventArgs e)
        {
            if(paisseleccionado!=null)
            {
                MessageBox.Show(paisneg.Modificarpais(codpais, txtNombre.Text));
                MostrarPaises();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un pais");
            }
        }
    }
}
