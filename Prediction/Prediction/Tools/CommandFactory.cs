using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Prediction.Tools
{
    public class CommandFactory : ICommandFactory
    {
        public ICommand Create(Func<Task> action)
        {
            return new Command(action);
        }

        public ICommand Create(Action action)
        {
            Task AsyncWrapper()
            {
                action();
                return Task.CompletedTask;
            }

            return new Command(AsyncWrapper);
        }

    }
}
