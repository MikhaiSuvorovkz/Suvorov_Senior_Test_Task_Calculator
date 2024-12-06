using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI.Views
{
    [RequireComponent(typeof(RectTransform))]
    public class DialogView : View, IDialogView
    {
        [SerializeField] private TMP_Text _messageText; // Текст ошибки
        [SerializeField] private Button _closeButton; // Кнопка закрытия
        [SerializeField] private RectTransform _rectTransform;

        public event Action Closed;

        private void OnValidate()
        {
            _rectTransform ??= GetComponent<RectTransform>();
        }

        private void Awake()
        {
            _closeButton.onClick.AddListener(OnCloseButtonClicked);
        }

        private void OnDestroy()
        {
            _closeButton.onClick.RemoveListener(OnCloseButtonClicked);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Return))
            {
                OnCloseButtonClicked();
            }
        }

        public void SetMessage(string message)
        {
            LayoutRebuilder.MarkLayoutForRebuild(_rectTransform);

            _messageText.text = message;

            LayoutRebuilder.ForceRebuildLayoutImmediate(_rectTransform);
        }

        private void OnCloseButtonClicked()
        {
            Closed?.Invoke();
            Hide();
        }
    }
}