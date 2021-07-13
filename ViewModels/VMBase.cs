using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ViewModels {
    public class VMBase : INotifyPropertyChanged {

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged([CallerMemberName] string propertyName = "") {
            ValidatePropertyName(propertyName);
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        //checks if property exist
        protected void ValidatePropertyName(string propertyName) {
            if (TypeDescriptor.GetProperties(this)[propertyName] == null) {
                throw new ArgumentException("Invalid property name: " + propertyName);
            }
        }
    }
}
