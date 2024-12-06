using UnityEngine;

namespace Game.UI.Views
{
    public class CalculatorViewFactory
    {
        private readonly Transform _parent;

        public CalculatorViewFactory(Transform parent)
        {
            _parent = parent;
        }

        public ICalculatorView Create()
        {
            var prefab = Resources.Load<CalculatorView>("CalculatorView");

            return Object.Instantiate(prefab, _parent);
        }
    }
}