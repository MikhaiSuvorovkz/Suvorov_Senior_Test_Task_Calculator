using System.Collections.Generic;

namespace Game.Core.Entities
{
    public class CalculationHistory : ICalculationHistory
    {
        private readonly List<string> _history = new();

        public IEnumerable<string> History => _history;

        public void Add(string input, string result)
        {
            if (!string.IsNullOrWhiteSpace(input) && !string.IsNullOrWhiteSpace(result))
            {
                var item = $"{input} = {result}";

                _history.Add(item);
            }
        }

        public void Load(string[] savedHistory)
        {
            _history.Clear();
            if (savedHistory != null)
            {
                _history.AddRange(savedHistory);
            }
        }
    }
}