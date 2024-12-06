using System;

namespace Game.Persistence
{
    [Serializable]
    public class CalculatorState
    {
        public string Expression;
        public string[] History;
    }
}