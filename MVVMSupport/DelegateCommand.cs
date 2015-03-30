using System;
using System.Windows.Input;

namespace MVVMLibrary
{
    public class DelegateCommand : ICommand
    {
        private Func<object, bool> canExecute;
        private Action<object> execute;

        private DelegateCommand()
        {
        }

        public DelegateCommand(Func<object, bool> canExecute, Action<object> execute)
        {
            this.canExecute = canExecute;
            this.execute = execute;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            if (this.canExecute == null)
            {
                return true;
            }
            else
            {
                return this.canExecute(parameter);
            }
        }

        public void Execute(object parameter)
        {
            this.execute(parameter);
        }

        public void RaiseCanExecuteChanged()
        {
            var handler = this.CanExecuteChanged;
            if (handler != null)
	        {
                handler(this, EventArgs.Empty);
	        }
        }
    }

    public class DelegateCommand<T> : ICommand
    {
        private Func<T, bool> canExecute;
        private Action<T> execute;

        private DelegateCommand()
        {
        }

        public DelegateCommand(Func<T, bool> canExecute, Action<T> execute)
        {
            this.canExecute = canExecute;
            this.execute = execute;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            if (this.canExecute == null)
            {
                return true;
            }
            else
            {
                return canExecute((T)parameter);
            }
        }

        public void Execute(object parameter)
        {
            this.execute((T)parameter);
        }

        public void RaiseCanExecuteChanged()
        {
            var handler = this.CanExecuteChanged;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }
    }
}
