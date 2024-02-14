using AIMTesterWPF.Database;
using AIMTesterWPF.UserControls;
using Microsoft.EntityFrameworkCore;
using System.Windows;
using System.Windows.Input;


namespace AIMTesterWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private GameCanvas gameCanvas = new GameCanvas();
        private ResultScreen resultScreen = new ResultScreen();

        public MainWindow()
        {
            InitializeComponent();
            startScreen.MouseLeftButtonDown += InitialiseStartScreen;
            resultScreen.MouseLeftButtonDown += InitialiseStartScreen;
            timer.Stoped += InitialiseResultScreen;
            using (ResultDataContext context = new ResultDataContext())
            {
                context.Results.Load();
                resultTable.ItemsSource = context.Results.Local.ToObservableCollection();
            }
        }

        private void InitialiseResultScreen(object? sender, EventArgs e)
        {
            contentPlaceholder.Children.Clear();
            int total = gameCanvas.Misses + gameCanvas.Hitts;
            int misses = gameCanvas.Misses;
            int hitts = gameCanvas.Hitts;
            double accuracy = (double)gameCanvas.Hitts / (gameCanvas.Hitts + gameCanvas.Misses);
            using (ResultDataContext context = new ResultDataContext())
            {
                context.Results.Add(new Result(total, misses, hitts, accuracy));
                context.SaveChanges();
                context.Results.Load(); 
                resultTable.ItemsSource = context.Results.Local.ToObservableCollection();
            }
            resultScreen.Misses = misses;
            resultScreen.Hitts = hitts;
            resultScreen.Accuracy = accuracy;
            contentPlaceholder.Children.Add(resultScreen);
        }

        private void InitialiseStartScreen(object sender, MouseButtonEventArgs e)
        {
            contentPlaceholder.Children.Clear();
            contentPlaceholder.Children.Add(gameCanvas);
            timer.Seconds = 10;
            timer.Start();
        }
    }
}