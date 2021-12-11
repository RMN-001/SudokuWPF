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
using System.Timers;
using System.Diagnostics;



namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string _startTimeDisplay = "00:00:00";
        private Stopwatch _stopwatch;
        private Timer _timer;
        

        
        public MainWindow()
        {
            InitializeComponent();
            TimeDisplay.Text=_startTimeDisplay;

            _stopwatch = new Stopwatch();
            _timer = new Timer(1000);

            _timer.Elapsed += OnTimerElapse;
        }

        private void  OnTimerElapse(object sender, ElapsedEventArgs e)
        {
            Application.Current.Dispatcher.Invoke(() => TimeDisplay.Text = _stopwatch.Elapsed.ToString(@"hh\:mm\:ss"));
        }

        private void  Start_Click(object sender, RoutedEventArgs e)
        {
            _stopwatch.Start();
            _timer.Start();
            Clear.IsEnabled = false;
            
        }

        private void  Stop_Click(object sender, RoutedEventArgs e)
        {
            _stopwatch.Stop();
            _timer.Stop();
            Clear.IsEnabled = true;
            Start.IsEnabled = false;
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            _stopwatch.Reset();
            TimeDisplay.Text = _startTimeDisplay;
            Start.IsEnabled = true;
        }
    }
}
