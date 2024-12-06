using UnityEngine;

namespace Game.Persistence
{
    public class CalculatorPersistence : IStatePersistence<CalculatorState>
    {
        public void SaveState(CalculatorState state)
        {
            string json = JsonUtility.ToJson(state);
            PlayerPrefs.SetString(CALCULATOR_STATE_NAME, json);
            PlayerPrefs.Save();
        }

        private const string CALCULATOR_STATE_NAME = nameof(CalculatorState);

        public CalculatorState LoadState()
        {
            
            if (PlayerPrefs.HasKey(CALCULATOR_STATE_NAME))
            {
                string json = PlayerPrefs.GetString(CALCULATOR_STATE_NAME);

                return JsonUtility.FromJson<CalculatorState>(json);
            }

            return new CalculatorState();
        }
    }
}