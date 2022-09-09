using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Prediction
{
    internal class Command : ICommand
    {
        private readonly Func<Task> _action;

        public Command(Func<Task> action)
        {
            _action = action;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public async void Execute(object? parameter)
        {
          await _action();
        }

        public event EventHandler? CanExecuteChanged;
    }
}
