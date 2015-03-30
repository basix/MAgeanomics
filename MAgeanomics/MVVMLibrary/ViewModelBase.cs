using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace MVVMLibrary
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChangedEvent([CallerMemberName]string propertyName="")
        {
            this.VerifyProperty(propertyName);

            var handler = this.PropertyChanged;

            if (handler != null)
            {
                var args = new PropertyChangedEventArgs(propertyName);
                handler(this, args);
            }
        }

        [Conditional("Debug")]
        private void VerifyProperty(string propertyName)
        {
            if (TypeDescriptor.GetProperties(this)[propertyName] == null) throw new MissingMemberException(this.GetType().ToString(), propertyName);
        }
    }
}
