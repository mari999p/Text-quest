using UnityEngine;

public class Step : MonoBehaviour
{
    #region Variables

    [TextArea(5, 10)] [SerializeField] private string _answers;

    [TextArea(3, 10)] [SerializeField] private string _description;

    [SerializeField] private Step[] _nexSteps;
    [SerializeField] private string _location;
    [SerializeField] private Sprite _locationImage;

    #endregion

    #region Properties

    public string Answers => _answers;
    public string Description => _description;
    public string Location => _location;
    public Sprite LocationImage => _locationImage;

    public Step[] NexSteps => _nexSteps;

    #endregion
}