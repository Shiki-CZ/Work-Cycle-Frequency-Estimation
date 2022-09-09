using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Prediction.Tools;

public interface ICommandFactory
{
    ICommand Create(Func<Task> action);
    ICommand Create(Action action);
}