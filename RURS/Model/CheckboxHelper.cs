using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using RURS.Annotations;
using RURS.ViewModel;

namespace RURS.Model
{
    class CheckboxHelper : VMBase
    {
        //private string _name;
        //private bool _isChecked;

        //public string Name
        //{
        //    get { return _name;}
        //    set
        //    {
        //        _name = value;
        //        OnPropertyChanged();
        //    }
        //}

        //public bool IsChecked
        //{
        //    get { return _isChecked; }
        //    set
        //    {
        //        _isChecked = value;
        //        OnPropertyChanged();
        //    }
        //}


        private int _index;

        public int Index
        {
            get { return _index; }
            set
            {
                _index = value;
                OnPropertyChanged();
            }
        }


        public CheckboxHelper()
        {
            //Name = name;
            Index = -1;
        }
    }
}
