using Prediction.ViewModels.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Prediction.Tools;

namespace Prediction.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private bool _isVisible = false;
        public string HeaderName { get; set; } = "My Tab Bjač";
        public bool IsVisible
        {
            get => _isVisible;
            set
            {
                _isVisible = value;
                OnPropertyChanged();
            }
        }

        public ICommand OnBtnCmd { get; set; }

        public MainViewModel(ICommandFactory commandFactory)
        {
            OnBtnCmd = commandFactory.Create(OnButton);
        }

        private void OnButton()
        {
            IsVisible = !IsVisible;
        }
    }
}
