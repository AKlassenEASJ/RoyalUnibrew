using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AdminRURS.Annotations;
using AdminRURS.Common;
using AdminRURS.Handler;
using ModelLibary.Models;

namespace AdminRURS.ViewModel
{
    public class FaerdigVareVM : INotifyPropertyChanged
    {

        #region Instancefields

        private FaerdigVare _selectedFaerdigVare;
    


        #endregion

        #region Properties      

        public ICommand CreateCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }        
        public FaerdigVareHandler Handler { get; set; }


        public FaerdigVare SelectedFaerdigVare
        {
            get { return _selectedFaerdigVare; }
            set
            {
                _selectedFaerdigVare = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Constructer
        // Uncomment
        public FaerdigVareVM()
        {           
            Handler = new FaerdigVareHandler(this);
            CreateCommand = new RelayCommand(Handler.Create);
            EditCommand = new RelayCommand(Handler.Edit);
            DeleteCommand = new RelayCommand(Handler.Delete);           
            SelectedFaerdigVare = new FaerdigVare();
        }

        #endregion

        #region Methods


        #endregion


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
 