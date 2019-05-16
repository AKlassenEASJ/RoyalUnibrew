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
{/// <summary>
/// hjælper til nulstille comboboxe
/// </summary>
    class CheckboxHelper : INotyfiClass
    {

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
            clear();
        }

        public void clear()
        {
            Index = -1;
        }
    }
}
