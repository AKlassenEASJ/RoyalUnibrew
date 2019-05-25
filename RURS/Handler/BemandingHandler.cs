using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLibary.Models;
using RURS.Common;
using RURS.Model;
using RURS.Persistency;
using RURS.Validation;
using RURS.ViewModel;

namespace RURS.Handler
{
    class BemandingHandler
    {
        #region InstanceFields

        private PersistenceBemanding<Bemanding> _persistence = new PersistenceBemanding<Bemanding>();
        private ValidationBemanding _validation = new ValidationBemanding();
        private string _errorMessage;

        #endregion

        #region Properties

        public BemandingViewModel BemandingViewModel { get; set; }

        #endregion

        #region Contructor

        public BemandingHandler(BemandingViewModel viewModel)
        {
            BemandingViewModel = viewModel;
        }


        #endregion

        #region Methods

        public async void AddAsync()
        {
            

            DateTime tempStartDateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, BemandingViewModel.StartTime.Hours, BemandingViewModel.StartTime.Minutes, 00, DateTimeKind.Local);
            DateTime tempEndDateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, BemandingViewModel.EndTime.Hours, BemandingViewModel.EndTime.Minutes, 00, DateTimeKind.Local);

            if (BemandingViewModel.EndTime.CompareTo(BemandingViewModel.StartTime) == -1 || BemandingViewModel.EndTime.CompareTo(BemandingViewModel.StartTime) == 0)
            {
                tempEndDateTime = tempEndDateTime.AddDays(1);
            }

            BemandingViewModel.Bemanding.Tidspunkt_Start = tempStartDateTime;
            BemandingViewModel.Bemanding.Tidspunkt_Slut = tempEndDateTime;

            BemandingViewModel.Bemanding.ProcessOrdre_Nr = SelectedPOSingleton.GetInstance().ActiveProcessOrdre.ProcessOrdreNr;

            foreach (var validation in BemandingViewModel.Validations)
            {
                if (validation.Value.Besked != null)
                {
                    AddToErrorMessage(validation.Key, validation.Value.Besked);
                }
            }

            if (_errorMessage != null)
            {
                MessageDialogHelper.Show(_errorMessage, "Angiv venligst følgende ting");
            }
            else
            {
                if (await _persistence.PostAsync(BemandingViewModel.Bemanding))
                {
                    BemandingViewModel.Bemanding = new Bemanding();
                    BemandingViewModel.Bemanding.Antal_Bemanding = 1;
                    BemandingViewModel.StartTime = new TimeSpan();
                    BemandingViewModel.EndTime = new TimeSpan();

                }
            }
            
        }

        public async void GetSuggestionsAsync()
        {
            List<Ansat> tempList = null;

            IEnumerable<string> suggestionList = null;

            if (BemandingViewModel.Bemanding.Signatur != null && BemandingViewModel.Bemanding.Signatur.Length >= 1)
            {
                tempList = await PersistenceAnsat.GetAllAsync();
            }
            else
            {
                BemandingViewModel.Suggestions = new List<string>(){"Ingen forslag"};
            }

            if (tempList != null)
            {
                suggestionList = from a in tempList
                    where a.Initial.StartsWith(BemandingViewModel.Bemanding.Signatur.ToUpperInvariant())
                    select a.Initial;

                if (suggestionList.Any())
                {
                    BemandingViewModel.Suggestions = suggestionList.ToList();
                }
                else
                {
                    BemandingViewModel.Suggestions = new List<string>() { "Ingen forslag" };
                }


            }

            

            








        }


        #endregion

        #region Validations

        public void ValidateEmployees()
        {
            BemandingViewModel.Validations["Employees"].Besked =
                _validation.BemandingTooSmall(BemandingViewModel.Bemanding.Antal_Bemanding);
        }

        public void ValidateBreaks()
        {
            BemandingViewModel.Validations["Breaks"].Besked =
                _validation.IntToSmall(BemandingViewModel.Bemanding.Pauser);
        }

        #endregion

        #region HelpMethods

        private void AddToErrorMessage(string name, string message)
        {
            _errorMessage = _errorMessage + $"\n{name}\n{message}";
        }

        #endregion
    }
}
