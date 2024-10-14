using System.Windows.Input;

namespace IPGeolocationApp.ViewModels
{
    public class RelayCommand : ICommand
    {
        private readonly Action<object?> _execute;

        public event EventHandler? CanExecuteChanged;

        public RelayCommand(Action<object?> execute)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
        }

        public bool CanExecute(object? parameter)
        {
            // Always return true to allow execution
            return true;
        }

        public void Execute(object? parameter)
        {
            _execute(parameter);
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
