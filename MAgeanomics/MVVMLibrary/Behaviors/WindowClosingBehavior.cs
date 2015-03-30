using System.Windows;

namespace MVVMLibrary
{
    public class WindowClosingBehavior : CommandBehaviorBase<WindowClosingBehavior>
    {
        protected override void OnAttach(DependencyObject dependencyObject)
        {
            var window = dependencyObject as Window;
            if (window != null)
            {
                window.Closing += this.window_Closing;
            }
        }

        protected override void OnDetatch(DependencyObject dependencyObject)
        {
            var window = dependencyObject as Window;
            if (window != null)
            {
                window.Closing -= this.window_Closing;
            }
        }

        private void window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.InvokeExecute((DependencyObject)sender);
        }
    }
}
