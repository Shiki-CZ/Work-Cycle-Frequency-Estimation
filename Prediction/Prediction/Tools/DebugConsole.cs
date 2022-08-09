using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prediction.Tools
{
    public class DebugConsole : IConsole
    {

        private string text = "";
        public event dText OnTextChanged;
        public delegate void dText(string text);

        public void AddLine(string line)
        {
            text += line + "\n";
            OnTextChanged?.Invoke(text);
        }

        public string Text { get => text; }
    }
}
