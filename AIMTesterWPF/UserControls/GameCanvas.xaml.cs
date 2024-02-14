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

namespace AIMTesterWPF.UserControls
{
    /// <summary>
    /// Interaction logic for gameCanvas.xaml
    /// </summary>
    public partial class GameCanvas : UserControl
    {
        public int Misses { get; private set; }
        public int Hitts { get; private set; }

        public GameCanvas()
        {
            InitializeComponent();
        }


        public void Reset()
        {
            Misses = 0;
            Hitts = 0;
        }

        private void PlaceAimOnRandomPosition()
        {
            double newLeft = Random.Shared.Next(Convert.ToInt32(buttonHolder.ActualWidth - aim.ActualWidth));
            double newTop = Random.Shared.Next(Convert.ToInt32(buttonHolder.ActualHeight - aim.ActualHeight));
            aim.Margin = new Thickness(newLeft, newTop, 0, 0);
        }

        private void ButtonHolderMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            PlaceAimOnRandomPosition();
            Misses++;
        }
        private void AimClick(object sender, RoutedEventArgs e)
        {
            PlaceAimOnRandomPosition();
            Hitts++;
        }

        private void ButtonHolderLoaded(object sender, RoutedEventArgs e)
        {
            PlaceAimOnRandomPosition();
        }
    }
}
