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

namespace bevolkingsgroei
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

        private void wissen_Click(object sender, RoutedEventArgs e)
        {
            textboxLand.Clear();
            textboxBevolking.Clear();
            textboxGroei.Clear();
            resultaat.Clear();
            textboxLand.Focus();
        }

        private void berekenen_Click(object sender, RoutedEventArgs e)
        {
            bool isValidAantalBevolking = double.TryParse(textboxBevolking.Text, out double bevolking);
            bool isValidPercentage = double.TryParse(textboxGroei.Text, out double percentage);
            string land = textboxLand.Text;
            double dubbelBevolking = bevolking * 2;
            int jaren = 0;

            if (percentage == 0 )
            {
                resultaat.Text = "Groeipercentage is nooit een verdubbeling van de bevolking";
            }
            else
            { 
            for (int i = 0; bevolking < dubbelBevolking; i++)
            {
                // berekenen van bevolking, 1,1% omzetten naar 1,011
                bevolking *= 1+(percentage/100);
                jaren++;
            }
            resultaat.Text = $"Verdubbeling bevolking in {land} na {jaren} jaar.\n" +
                    $"Nieuw bevolkingsaantal op dat moment: {bevolking:F0}";
            }

        }

        private void afsluiten_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
