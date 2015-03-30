using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MVVMLibrary
{
    public class DoubleClickBehavior : CommandBehaviorBase<DoubleClickBehavior>
    {
        protected override void OnAttach(DependencyObject dependencyObject)
        {
            var control = dependencyObject as Control;

            if (control != null)
            {
                control.MouseDoubleClick += this.ControlMouseDoubleClick;
            }
        }

        protected override void OnDetatch(DependencyObject dependencyObject)
        {
            var control = dependencyObject as Control;

            if (control != null)
            {
                control.MouseDoubleClick -= this.ControlMouseDoubleClick;
            }
        }

        private void ControlMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            this.InvokeExecute((DependencyObject)sender);
        }
    }
}
