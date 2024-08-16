using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    [SerializeField] private Button _startButton;

    private void Start()
    {
        _startButton.onClick.AddListener(EnterGame);
    }

    private void EnterGame()
    {
        SceneManager.LoadScene("GameScene");
    }
}