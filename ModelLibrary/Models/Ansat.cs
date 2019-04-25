using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary.Models
{
    public class Ansat
    {

        #region InstanceFields

        private string _initial;
        private string _navn;
        private int _iD;

        #endregion

        #region Properties

        public string Initial
        {
            get => _initial;
            set => _initial = value;
        }

        public string Navn
        {
            get => _navn;
            set => _navn = value;
        }

        public int ID
        {
            get => _iD;
            set => _iD = value;
        }


        #endregion


        #region Constructor

        public Ansat(string initial, string navn, int id)
        {
            _initial = initial;
            _navn = navn;
            _iD = id;

        }


        #endregion

        #region Methods

        public override string ToString()
        {
            return $"{nameof(Initial)}: {Initial}, {nameof(Navn)}: {Navn}, {nameof(ID)}: {ID}";
        }

        #endregion


    }
}
