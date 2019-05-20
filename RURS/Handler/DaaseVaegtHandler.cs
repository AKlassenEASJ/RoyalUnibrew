using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RURS.Model;
using RURS.ViewModel;

namespace RURS.Handler
{
    class DaaseVaegtHandler
    {
        private DaaseVaegtViewModel _viewModel;

        public DaaseVaegtHandler(DaaseVaegtViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public void add()
        {

        }

        public void GetValues()
        {
            GetMin();
            GetSnit();
            GetMax();
        }

        private void GetMax()
        {
            _viewModel.Maximum = new ObservableCollection<Record>();
            _viewModel.Maximum.Add(new Record(1, 352.1));
            _viewModel.Maximum.Add(new Record(24, 352.1));
        }

        private void GetMin()
        {
            _viewModel.Minimum = new ObservableCollection<Record>();
            _viewModel.Minimum.Add(new Record(1, 336.9));
            _viewModel.Minimum.Add(new Record(24, 336.9));
        }

        private void GetSnit()
        {
            _viewModel.Snit = new ObservableCollection<Record>();
            _viewModel.Snit.Add(new Record(1, 347));
            _viewModel.Snit.Add(new Record(24, 347));
        }
    }
}
