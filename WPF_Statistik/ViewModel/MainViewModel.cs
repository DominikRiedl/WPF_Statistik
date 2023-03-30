using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Statistik
{
    public class MainViewModel : BaseModel
    {
        private ObservableCollection<Data> _lstData;
        public ObservableCollection<Data> LstData
        {
            get { return _lstData; }
            set
            {
                _lstData = value;
                OnPropertyChanged("LstData");
            }
        }

        private Data _selData;
        public Data SelData
        {
            get
            {
                return _selData;
            }

            set
            {
                this._selData = value;

                if (this._selData != null)
                    this.IsDataSelected = true;
                else
                    this.IsDataSelected = false;

                OnPropertyChanged("SelData");
            }
        }

        private bool _isDataSelected = false;
        public bool IsDataSelected
        {
            get
            {
                return _isDataSelected;
            }
            set
            {
                _isDataSelected = value;
                OnPropertyChanged("IsDataSelected");
            }
        }

        #nullable disable
        public MainViewModel()
        {
            // Hier wird aus der List eine ObservableCollection
            this.LstData = new ObservableCollection<Data>(Data.AlleLesen());
        }
        #nullable enable
    }
}
