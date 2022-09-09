using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prediction.Tools;
using Prediction.ViewModels.Abstraction;

namespace Prediction.ViewModels
{
    public class ConsoleViewModel : ViewModelBase
    {
        private readonly IConsole _console;
        private string _text;

        public event Action OnTextChanged;

        public string Text
        {
            get => _text;
            set
            {
                _text = value;
                OnPropertyChanged();
                OnTextChanged?.Invoke();
        }
        }

        public ConsoleViewModel(IConsole console)
        {
            _console = console;
            _console.OnTextChanged += _console_OnTextChanged;
            Text = _console.Text;
        }

        private void _console_OnTextChanged(string text)
        {
            Text = text;
        }
    }
}
