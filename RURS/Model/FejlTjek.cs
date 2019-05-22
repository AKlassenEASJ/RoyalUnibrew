using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RURS.Model
{
    class FejlTjek : INotyfiClass
    {
        
        private string _besked;

        public string Besked
        {
            get { return _besked;}
            set
            {
                _besked = value;
                OnPropertyChanged();
            }
        }

        public FejlTjek()
        {
            _besked = null;
        }

        
    }
}
