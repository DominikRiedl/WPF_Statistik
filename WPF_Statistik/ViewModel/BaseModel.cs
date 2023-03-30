using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Statistik
{
    public class BaseModel : INotifyPropertyChanged
    {
        // Declare the PropertyChanged event
        #nullable disable
        public event PropertyChangedEventHandler PropertyChanged;
        #nullable enable
        // OnPropertyChanged will raise the PropertyChanged event passing the
        // source property that is being updated.
        protected void OnPropertyChanged(String propertyName)
        {
            if (this.PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
