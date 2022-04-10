namespace Chestnut_Pro.Model
{
    /// <summary>
    /// Snackbar Warning Message
    /// </summary>
    public class WarningMessage
    {
        public WarningMessage(bool active, string message)
        {
            this.IsActive = active;
            this.Msg = message;
        }

        public WarningMessage()
        {
            this.IsActive = false;
            this.Msg = string.Empty;
        }

        /// <summary>
        /// Is Active
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Message
        /// </summary>
        public string Msg { get; set; }
    }
}
