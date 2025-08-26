using UnityEngine;
using UnityEngine.SceneManagement;

public class Trap : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverPanel;
    private bool _isGameOver = false;

    private void Start()
    {
        if (_gameOverPanel != null)
            _gameOverPanel.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_isGameOver)
            return;

        if (other.CompareTag("Player"))
        {
            _isGameOver = true;

            if (_gameOverPanel != null)
                _gameOverPanel.SetActive(true);

            Time.timeScale = 0f;
        }
    }

    public void RestartLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ExitToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenuScene");
    }
}
