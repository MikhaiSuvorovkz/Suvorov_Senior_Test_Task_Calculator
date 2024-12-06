using System;
using System.Collections.Generic;

namespace Game.UI.Views
{
    public interface ICalculatorView : IView
    {
        void UpdateHistory(IEnumerable<string> history);
        void SetInputText(string calculatorStateExpression);
        string GetCurrentInput();
        event Action<string> Clicked;
    }
}