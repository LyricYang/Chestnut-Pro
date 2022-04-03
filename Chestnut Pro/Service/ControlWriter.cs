namespace Chestnut_Pro.Service
{
    using System;
    using System.IO;
    using System.Text;
    using System.Windows.Controls;

    public class ControlWriter : TextWriter
    {
        TextBox textBox = null;

        public ControlWriter(TextBox output)
        {
            textBox = output;
        }

        public override void Write(char value)
        {
            base.Write(value);
            textBox.Dispatcher.BeginInvoke(new Action(() =>
            {
                textBox.AppendText(value.ToString());
            }));
        }

        public override Encoding Encoding
        {
            get { return System.Text.Encoding.UTF8; }
        }
    }
}
