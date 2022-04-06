namespace Chestnut_Pro
{
    using System;
    using System.Windows.Input;

    /// <summary>
    /// RelayCommand allows you to inject the command's logic via delegates passed into its constructor.
    /// This method enables ViewModel classes to implement commands in a concise manner.
    /// </summary>
    public class RelayCommand : ICommand
    {
        private Action<object?> execute;
        private Func<object?, bool> canExecute;

        /// <summary>
        /// The Constructor
        /// </summary>
        /// <param name="execute"></param>
        public RelayCommand(Action<object?> execute)
        {
            this.execute = execute;
            canExecute = null;
        }

        /// <summary>
        /// The Constructor
        /// </summary>
        /// <param name="execute"></param>
        /// <param name="canExecute"></param>
        public RelayCommand(Action<object?> execute, Func<object?, bool> canExecute)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        /// <summary>
        /// CanExecuteChanged delegates the event subscription to the CommandManager.RequerySuggested event.
        /// This ensures that the WPF commanding infrastructure asks all RelayCommand objects if they can execute whenever
        /// it asks the built-in commands.
        /// </summary>
        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value;}
        }

        /// <summary>
        /// Can Execute
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object? parameter)
        {
            return canExecute == null || canExecute(parameter);
        }

        /// <summary>
        /// Execute
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object? parameter)
        {
            execute(parameter);
        }
    }
}
