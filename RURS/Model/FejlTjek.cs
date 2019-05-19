using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RURS.Model
{
    class FejlTjek : INotyfiClass
    {
        
        private string _bedsked;

        public string Bedsked
        {
            get { return _bedsked;}
            set
            {
                _bedsked = value;
                OnPropertyChanged();
            }
        }

        public FejlTjek()
        {
            _bedsked = null;
        }

        
    }
}
