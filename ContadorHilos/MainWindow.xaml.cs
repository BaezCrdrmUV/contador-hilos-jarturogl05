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
using System.Threading;

namespace ContadorHilos
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public delegate void actualizarIU(TextBlock textBlock, string contador);

        public MainWindow()
        {
            InitializeComponent();
        }


        private void btn_ContadorA_Click(object sender, RoutedEventArgs e)
        {
            if (cbx_hilos.IsChecked.Value)
            {
                Thread hilo = new Thread(IniciarHilo);
                hilo.Start();
            }
            else
            {
                ContadorAutoSinHilo();
            }



        }

        private void btn_ContadorM_Click(object sender, RoutedEventArgs e)
        {
            int contadorManual = 1;
            contadorManual++;
            txb_ContadorM.Text = contadorManual.ToString();
        }


        private void ContadorAutoSinHilo()
        {

            int contadorAuto = 1;
            while (contadorAuto <= 100)
            {
                txb_ContadorA.Text = contadorAuto.ToString();
                contadorAuto++;
                Thread.Sleep(1000);
            }
        }


        private void IniciarHilo()
        {

            int contadorAuto = 1;
            while (contadorAuto <= 100)
            {
                txb_ContadorA.Dispatcher.Invoke(new Action(() =>
                {
                    txb_ContadorA.Text = contadorAuto.ToString();
                }));
                contadorAuto++;
                Thread.Sleep(1000);
            }


        }
    }
}
