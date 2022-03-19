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

        /// <summary>
        /// The Constructor
        /// </summary>
        public TimestampConverterView()
        {
            InitializeComponent();
            Timer.Tick += new EventHandler(TimeClick);
            Timer.Interval = new TimeSpan(0, 0, 1);
            Timer.Start();
        }

        /// <summary>
        /// Time Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UnixToDateTime(object sender, System.Windows.RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(UnixTimestamp?.Text))
            {
                var timestamp = Convert.ToInt64(UnixTimestamp?.Text);
                var ticks = timestamp * 10000 + 621355968000000000;
                var datetime = new DateTime(ticks);
                DateTimeTextBox.Text = datetime.ToLocalTime().ToString();
            }
        }

        private void DateTimeToUnix(object sender, System.Windows.RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(DatePick?.Text) && !string.IsNullOrEmpty(TimePick?.Text))
            {
                var timePicker = $"{DatePick.Text} {TimePick.Text}";
                var datetime = DateTime.Parse(timePicker).ToUniversalTime();
                var timestamp = (datetime.Ticks - 621355968000000000) / 10000;
                UnixTimestamp.Text = timestamp.ToString();
            }
        }
    }
}
