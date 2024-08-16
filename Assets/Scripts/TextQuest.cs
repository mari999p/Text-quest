using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TextQuest : MonoBehaviour
{
    #region Variables

    [Header("UI")] [SerializeField] private TMP_Text _descriptionLabel;

    [SerializeField] private TMP_Text _answerLabel;
    [SerializeField] private TMP_Text _locationLabel;
    [SerializeField] private Button _button1;
    [SerializeField] private Button _button2;
    [SerializeField] private Button _button3;
    [SerializeField] private Button _button4;

    [Header("Settings")] [SerializeField] private Step _startStep;

    [Header("DEBUG")] [SerializeField] private Step _currentStep;

    [SerializeField] private Image _locationImage;

    public static int MovesCount { get; private set; }

    #endregion

    #region Unity lifecycle
    

    private void Start()
    {
        _button1.onClick.AddListener(() => TryGoNextStep(1));
        _button2.onClick.AddListener(() => TryGoNextStep(2));
        _button3.onClick.AddListener(() => TryGoNextStep(3));
        _button4.onClick.AddListener(() => TryGoNextStep(4));
        MovesCount = 0;
        SetCurrentStepAndUpdateUi(_startStep);
    }

    private void Update()
    {
        for (int i = 1; i <= 9; i++)
            if (Input.GetKeyDown(i.ToString()))
                TryGoNextStep(i);
    }

    private void OnDestroy()
    {
        Debug.Log($"TextQuest MovesCount '{MovesCount}'");
    }

    private void GoToGameOverScene()
    {
        SceneManager.LoadScene("GameOverScene");
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
        if (_currentStep.NexSteps.Length == 0)
        {
            GoToGameOverScene();
            return;
        }

        int nexStepsCount = _currentStep.NexSteps.Length;
        if (number > nexStepsCount) return;
        MovesCount++;

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