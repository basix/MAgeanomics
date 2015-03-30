using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MVVMLibrary
{
    public class TreeViewSelectedItemChangedBehavior : CommandBehaviorBase<TreeViewSelectedItemChangedBehavior>
    {
        protected override void OnAttach(DependencyObject dependencyObject)
        {
            TreeView treeView = dependencyObject as TreeView;
            if (treeView != null)
            {
                treeView.SelectedItemChanged += treeView_SelectedItemChanged;
            }
        }

        protected override void OnDetatch(DependencyObject dependencyObject)
        {
            TreeView treeView = dependencyObject as TreeView;
            if (treeView != null)
            {
                treeView.SelectedItemChanged -= treeView_SelectedItemChanged;
            }
        }

        void treeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            this.InvokeExecute((DependencyObject)sender);
        }
    }
}
