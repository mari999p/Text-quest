using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    #region Variables

    [SerializeField] private Button _startButton;
    [SerializeField] private TMP_Text _headerLabel;

    #endregion

    #region Unity lifecycle

    private void Start()
    {
        _startButton.onClick.AddListener(EnterGame);
        _headerLabel.text = $"Game Over!\nYour moves: {TextQuest.MovesCount}";
    }

    #endregion

    #region Private methods

    private void EnterGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    #endregion
}