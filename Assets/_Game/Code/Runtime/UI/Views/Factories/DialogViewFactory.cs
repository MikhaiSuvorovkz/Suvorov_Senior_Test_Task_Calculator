using UnityEngine;

namespace Game.UI.Views
{
    public class DialogViewFactory
    {
        private readonly Transform _parent;

        public DialogViewFactory(Transform parent)
        {
            _parent = parent;
        }
        public IDialogView Create()
        {
            var prefab = Resources.Load<DialogView>("DialogView");

            return Object.Instantiate(prefab, _parent);
        }
    }
}