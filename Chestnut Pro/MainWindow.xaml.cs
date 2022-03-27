namespace Chestnut_Pro
{
    using System;
    using System.Windows;
    using System.Windows.Threading;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer;
        bool hidden = true;
        double maxWidth = 1360;
        double minWidth = 1160;

        public MainWindow()
        {
            InitializeComponent();
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 0, 10);
            timer.Tick += TimerTick;
        }

        /// <summary>
        /// Timer Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimerTick(object sender, EventArgs e)
        {
            if (hidden)
            {
                DashboardWindow.Width += 100;
                if (DashboardWindow.Width >= maxWidth)
                {
                    timer.Stop();
                    hidden = false;
                }
            }
            else
            {
                DashboardWindow.Width -= 100;
                if (DashboardWindow.Width <= minWidth)
                {
                    timer.Stop();
                    hidden = true;
                }
            }
        }

        /// <summary>
        /// Collapse Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CollapseClick (object sender, RoutedEventArgs e)
        {
            timer.Start();
        }
    }
}
