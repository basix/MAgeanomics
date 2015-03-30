using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MVVMLibrary
{
    public class ListViewSelectedItemChangedBehavior : CommandBehaviorBase<ListViewSelectedItemChangedBehavior>
    {

        protected override void OnAttach(System.Windows.DependencyObject dependencyObject)
        {
            var listView = dependencyObject as ListView;
            if (listView != null)
            {
                listView.SelectionChanged += listView_SelectionChanged;
            }
        }

        protected override void OnDetatch(System.Windows.DependencyObject dependencyObject)
        {
            var listView = dependencyObject as ListView;
            if (listView != null)
            {
                listView.SelectionChanged -= listView_SelectionChanged;
            }
        }

        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.InvokeExecute((DependencyObject)sender);
        }
    }
}
