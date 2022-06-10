using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prediction.Core.Curve.Extremes.Abstraction;
using Prediction.ViewModels.Abstraction;

namespace Prediction.ViewModels
{
    internal class TabTestViewModel : ViewModelBase
    {
        public TabTestViewModel(IExtremes computer)
        {
            _computer = computer;
        }

        public string HeaderName
        {
            get
            {
                _headerName += "  ";
                return _headerName;
            }
            set
            {
                _headerName = value; 
                OnPropertyChanged();
            }
        }

        private readonly IExtremes _computer;
        private string _headerName = "My new Tab";
    }
}
