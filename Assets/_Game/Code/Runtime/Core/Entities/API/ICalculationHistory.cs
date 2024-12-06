using System.Collections.Generic;

namespace Game.Core.Entities
{
    public interface ICalculationHistory
    {
        void Add(string input, string result);
        IEnumerable<string> History { get; }
        void Load(string[] savedHistory);
    }
}