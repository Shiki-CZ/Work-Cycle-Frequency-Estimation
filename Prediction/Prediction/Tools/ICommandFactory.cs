using System;
using System.Windows.Input;

namespace Prediction.Tools;

public interface ICommandFactory
{
    ICommand Create(Action action);
}