using System.Windows;
using System.Windows.Input;

namespace MVVMLibrary
{
    public abstract class CommandBehaviorBase<T> where T : CommandBehaviorBase<T>, new ()
    {
        private static T instance;

        static CommandBehaviorBase()
        {
            instance = new T();
        }
 
        #region DependencyProperties

        public static readonly DependencyProperty CommandProperty = DependencyProperty.RegisterAttached(
            "Command",
            typeof(ICommand),
            typeof(CommandBehaviorBase<T>),
            new PropertyMetadata(null, CommandPropertyChanged));

        public static readonly DependencyProperty CommandParameterProperty = DependencyProperty.RegisterAttached(
            "CommandParameter",
            typeof(object),
            typeof(CommandBehaviorBase<T>),
            new PropertyMetadata(null));

        #endregion DependencyProperties

        #region Static Get/Set Methods

        public static ICommand GetCommand(DependencyObject dependencyObject)
        {
            return (ICommand)dependencyObject.GetValue(CommandProperty);
        }

        public static void SetCommand(DependencyObject dependencyObject, ICommand value)
        {
            dependencyObject.SetValue(CommandProperty, value);
        }

        public static object GetCommandParameter(DependencyObject dependencyObject)
        {
            return dependencyObject.GetValue(CommandParameterProperty);
        }

        public static void SetCommandParameter(DependencyObject dependencyObject, object value)
        {
            dependencyObject.SetValue(CommandProperty, value);
        }

        #endregion Static Get/Set Methods

        private static void CommandPropertyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            if (e.OldValue == null && e.NewValue != null)
            {
                instance.OnAttach(dependencyObject);
            }

            if (e.OldValue != null && e.NewValue == null)
            {
                instance.OnDetatch(dependencyObject);
            }
        }

        protected abstract void OnAttach(DependencyObject dependencyObject);

        protected abstract void OnDetatch(DependencyObject dependencyObject);

        protected virtual void InvokeExecute(DependencyObject dependencyObject)
        {
            var command = GetCommand(dependencyObject);
            var commandParameter = GetCommandParameter(dependencyObject);

            if (command != null && command.CanExecute(commandParameter))
            {
                command.Execute(commandParameter);
            }
        }
    }
}
