namespace Chestnut_Pro.View
{
    using System;
    using System.Windows.Controls;

    /// <summary>
    /// Interaction logic for DocumentView.xaml
    /// </summary>
    public partial class TimestampConverterView : UserControl
    {
        System.Windows.Threading.DispatcherTimer Timer = new System.Windows.Threading.DispatcherTimer();

        public TimestampConverterView()
        {
            InitializeComponent();
            Timer.Tick += new EventHandler(TimeClick);
            Timer.Interval = new TimeSpan(0, 0, 1);
            Timer.Start();
        }

        private void TimeClick(object sender, EventArgs e)
        {
            var utc = new DateTimeOffset(DateTime.UtcNow);
            var usTime = utc.ToOffset(TimeSpan.FromHours(-8));
            var inTime = utc.ToOffset(TimeSpan.FromMinutes(330));
            var cnTime = utc.ToOffset(TimeSpan.FromHours(8));

            USTime.Content = $"US(UTC-8:00): {usTime}";
            INTime.Content = $"IN(UTC+5:30): {inTime}";
            CNTime.Content = $"IN(UTC+8:00): {cnTime}";
        }
    }
}
