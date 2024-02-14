using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AIMTesterWPF.Database
{
    public class Result :INotifyPropertyChanged
    {
        private int total;
        private int misses;
        private int hitts;
        private double accuracy;

        public Result(int total, int misses, int hitts, double accuracy)
        {
            Total = total;
            Misses = misses;
            Hitts = hitts;
            Accuracy = accuracy;
        }

        public int Id { get; set; }
        public int Total 
        { 
            get => total;
            set
            {
                total = value;
                OnPropertyChanged("Total");
            }
        }
        public int Misses 
        {
            get => misses; 
            set
            {
                misses = value;
                OnPropertyChanged("Misses");
            }
        }

        public int Hitts
        {
            get => hitts;
            set
            {
                hitts = value;
                OnPropertyChanged("Hits");
            }
        }
        public double Accuracy 
        { 
            get => accuracy; 
            set
            {
                accuracy = value;
                OnPropertyChanged("Accuracy"); 
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
    }
}
