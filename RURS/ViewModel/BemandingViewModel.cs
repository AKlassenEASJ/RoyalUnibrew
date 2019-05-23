using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ModelLibary.Models;
using RURS.Common;
using RURS.Handler;
using RURS.Model;

namespace RURS.ViewModel
{
    class BemandingViewModel : VMBase
    {
        #region InstanceFields

        private TimeSpan _startTime;
        private TimeSpan _endTime;
        private Bemanding _nyBemanding = new Bemanding();
        private ICommand _addCommand;
        private ICommand _validateEmployeesCommand;
        private ICommand _validateBreaksCommand;
        private ICommand _getSuggestionsCommand;
        private Dictionary<string, FejlTjek> _validations = new Dictionary<string, FejlTjek>();
        private List<string> _suggestions = new List<string>();


        #endregion

        #region Properties

        public TimeSpan StartTime
        {
            get { return _startTime; }
            set
            {
                _startTime = value; 
                OnPropertyChanged();
            }
        }

        public TimeSpan EndTime
        {
            get { return _endTime; }
            set
            {
                _endTime = value; 
                OnPropertyChanged();
            }
        }

        public Bemanding Bemanding
        {
            get { return _nyBemanding; }
            set
            {
                _nyBemanding = value; 
                OnPropertyChanged();
            }
        }

        public ICommand AddCommand
        {
            get { return _addCommand; }
            set { _addCommand = value; }
        }

        public ICommand ValidateEmployeesCommand
        {
            get {return _validateEmployeesCommand;}
            set { _validateEmployeesCommand = value; }
        }

        public ICommand ValidateBreaksCommand
        {
            get { return _validateBreaksCommand; }
            set { _validateBreaksCommand = value; }
        }

        public ICommand GetSuggestionsCommand
        {
            get { return _getSuggestionsCommand; }
            set { _getSuggestionsCommand = value; }
        }

        public Dictionary<string, FejlTjek> Validations
        {
            get { return _validations; }
            set { _validations = value; }
        }

        public List<string> Suggestions
        {
            get { return _suggestions; }
            set
            {
                _suggestions = value; 
                OnPropertyChanged();
            }
        }

        public BemandingHandler BemandingHandler { get; set; }


        #endregion

        #region Constructor

        public BemandingViewModel()
        {
            BemandingHandler = new BemandingHandler(this);
            _addCommand = new RelayCommand(BemandingHandler.AddAsync);
            _validateEmployeesCommand = new RelayCommand(BemandingHandler.ValidateEmployees);
            _validateBreaksCommand = new RelayCommand(BemandingHandler.ValidateBreaks);
            _getSuggestionsCommand = new RelayCommand(BemandingHandler.GetSuggestionsAsync);
            _startTime = DateTime.Now.TimeOfDay;
            _endTime = DateTime.Now.TimeOfDay.Add(new TimeSpan(01, 00, 00));
            AddValidations();
            
        }


        #endregion

        #region Methods



        #endregion

        #region HelpMethods

        private void AddValidations()
        {
            _validations.Add("Employees", new FejlTjek());
            _validations.Add("Breaks", new FejlTjek());
        }

        #endregion

    }
}
