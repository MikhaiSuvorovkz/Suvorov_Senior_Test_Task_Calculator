

using System.Linq;
using Game.UI.Presenters;
using UnityEngine;

namespace Game.EntryPoint
{
    using Core.Entities.Factories;
    using Core.Entities;
    using Persistence;
    using UI;
    using UI.Views;

    public class CalculatorEntryPoint : MonoBehaviour
    {
        private ICalculatorView _calculatorView;

        [SerializeField] private Transform _canvas;

        private CalculatorPresenter _calculatorPresenter;
        private ICalculationHistory _calculationHistory;
        private IUIController _uiController;
        private IStatePersistence<CalculatorState> _persistence;

        private void Awake()
        {
            var calculatorViewFactory = new CalculatorViewFactory(_canvas);
            _calculatorView = calculatorViewFactory.Create();

            var dialogViewFactory = new DialogViewFactory(_canvas);

            IDialogView dialogView = dialogViewFactory.Create();

            var dialogModelFactory = new DialogModelFactory();
            var errorDialogModel = dialogModelFactory.Create();
            var errorDialogPresenter = new DialogPresenter(errorDialogModel, dialogView);

            var calculator = new CalculatorFactory().Create();
            _persistence = new CalculatorPersistence();

            var calculationHistoryFactory = new CalculationHistoryFactory();
            
            _calculationHistory = calculationHistoryFactory.Create();

            _calculatorPresenter = new CalculatorPresenter
                (calculator, _calculatorView, _calculationHistory);

            var uiControllerFactory = new UIControllerFactory();

            _uiController = uiControllerFactory.Create(_calculatorView, dialogView, _calculatorPresenter, errorDialogPresenter);
        }

        private void Start()
        {
            CalculatorState calculatorState = _persistence.LoadState();

            _calculationHistory.Load(calculatorState.History);
            _calculatorView.SetInputText(calculatorState.Expression);
            _calculatorView.UpdateHistory(_calculationHistory.History);

            _uiController.Initialize();
        }

        private void OnDestroy()
        {
            _uiController.Dispose();
        }

        private void OnApplicationQuit()
        {
            // Сохраняем состояние приложения при выходе
            var state = new CalculatorState
            {
                Expression = _calculatorView.GetCurrentInput(),
                History = _calculationHistory.History.ToArray()
            };

            _persistence.SaveState(state);
        }
    }
}