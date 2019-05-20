using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RURS.Model
{
    class Record : INotyfiClass
    {
        private int _name;
        private double _amount;

        public int Name
        {
            get { return _name;}
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        public double Amount
        {
            get { return _amount;}
            set
            {
                _amount = value;
                OnPropertyChanged();
            }
        }

        public Record(int name, double amount)
        {
            Name = name;
            Amount = amount;
        }
    }
}
