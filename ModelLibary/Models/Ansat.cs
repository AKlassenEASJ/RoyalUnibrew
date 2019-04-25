using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibary.Models
{
    public class Ansat
    {

        #region InstanceFields

        private string _Initial;
        private string _navn;
        private int _id;

        #endregion

        #region Properties

        public string Initial
        {
            get => _Initial;
            set => _Initial = value;
        }

        public string Navn
        {
            get => _navn;
            set => _navn = value;
        }

        public int Id
        {
            get => _id;
            set => _id = value;
        }

        #endregion

        #region Constructor

        public Ansat(string initial, string navn, int id)
        {
            _Initial = initial;
            _navn = navn;
            _id = id;

        }

        #endregion

        #region Methods

        public override string ToString()
        {
            return $"{nameof(Initial)}: {Initial}, {nameof(Navn)}: {Navn}, {nameof(Id)}: {Id}";
        }

        #endregion

    }
}
