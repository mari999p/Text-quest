using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextQuest : MonoBehaviour
{
    #region Variables

    [SerializeField] private TMP_Text _descriptionLabel;
    [SerializeField] private TMP_Text _answerLabel;
    [SerializeField] private TMP_Text _locationLabel;

    [SerializeField] private Step _startStep;

    [SerializeField] private Step _currentStep;

    [SerializeField] private Image _locationImage;

    #endregion

    #region Unity lifecycle

    private void Start()
    {
        SetCurrentStepAndUpdateUi(_startStep);
    }

    private void Update()
    {
        for (int i = 1; i <= 9; i++)
        {
            if (Input.GetKeyDown(i.ToString()))
            {
                TryGoNextStep(i);
            }
        }
    }

    #endregion

    #region Private methods

    private void SetCurrentStepAndUpdateUi(Step step)
    {
        _currentStep = step;
        UpdateUi();
    }

    private void TryGoNextStep(int number)
    {
        int nexStepsCount = _currentStep.NexSteps.Length;
        if (number > nexStepsCount)
        {
            return;
        }

        int nexStepIndex = number - 1;
        Step nextStep = _currentStep.NexSteps[nexStepIndex];
        SetCurrentStepAndUpdateUi(nextStep);
    }

    private void UpdateUi()
    {
        _descriptionLabel.text = _currentStep.Description;
        _answerLabel.text = _currentStep.Answers;
        _locationLabel.text = _currentStep.Location;
        _locationImage.sprite = _currentStep.LocationImage;
    }

    #endregion
}