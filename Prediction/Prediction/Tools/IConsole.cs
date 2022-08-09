namespace Prediction.Tools;

public interface IConsole
{
    event DebugConsole.dText OnTextChanged;
    void AddLine(string line);

    string Text { get; }
}