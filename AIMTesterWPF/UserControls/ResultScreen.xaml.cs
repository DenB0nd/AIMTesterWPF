using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for ResultScreen.xaml
    /// </summary>
    public partial class ResultScreen : UserControl, INotifyPropertyChanged
    {
        private int hitts;

        public int Hitts
        {
            get => hitts;
            set
            {
                hitts = value;
                RaisePropertyChanged(nameof(Hitts));
            }
        }
        private int misses;


        public int Misses
        {
            get => misses;
            set
            {
                misses = value;
                RaisePropertyChanged(nameof(Misses));
            }
        }

        private double accuracy;
        public double Accuracy
        {
            get => accuracy;
            set
            {
                accuracy = value;
                RaisePropertyChanged(nameof(Accuracy));
            }
        }

        public ResultScreen()
        {
            InitializeComponent();
            this.DataContext = this;
        }


        public event PropertyChangedEventHandler? PropertyChanged;

        private void RaisePropertyChanged(string propertyName)
        {
            // take a copy to prevent thread issues
            PropertyChangedEventHandler? handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
