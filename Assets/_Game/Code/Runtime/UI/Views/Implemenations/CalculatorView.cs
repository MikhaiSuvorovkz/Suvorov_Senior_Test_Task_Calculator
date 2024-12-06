using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI.Views
{
    [RequireComponent(typeof(RectTransform))]
    public class CalculatorView : View, ICalculatorView
    {
        [SerializeField] private TMP_InputField _inputField;
        [SerializeField] private TextMeshProUGUI _historyText;
        [SerializeField] private Button _calculateButton;

        [SerializeField] private RectTransform _rectTransform;
        [SerializeField] private VerticalLayoutGroup _verticalLayoutGroup;

        public event Action<string> Clicked;

        private void OnValidate()
        {
            _rectTransform ??= GetComponent<RectTransform>();
            _verticalLayoutGroup ??= GetComponent<VerticalLayoutGroup>();
        }

        private void Awake()
        {
            _calculateButton.onClick.AddListener(OnCalculateButtonClicked);
        }

        private void OnDestroy()
        {
            _calculateButton.onClick.RemoveListener(OnCalculateButtonClicked);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                OnCalculateButtonClicked();
            }
        }

        private void OnCalculateButtonClicked()
        {
            Clicked?.Invoke(_inputField.text);
        }

        public void UpdateHistory(IEnumerable<string> history)
        {
            _historyText.text = string.Join("\n", history);

            _verticalLayoutGroup.CalculateLayoutInputVertical();
            LayoutRebuilder.ForceRebuildLayoutImmediate(_historyText.rectTransform);
            LayoutRebuilder.ForceRebuildLayoutImmediate(_rectTransform);
        }

        public string GetCurrentInput()
        {
            return _inputField.text;
        }

        public void SetInputText(string text)
        {
            _inputField.text = text;
        }
    }
}