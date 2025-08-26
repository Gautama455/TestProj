using UnityEngine;
using UnityEngine.SceneManagement;

public class Trap : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverPanel; // —сылка на панель Game Over UI

    private bool _isGameOver = false;

    private void Start()
    {
        // —крываем панель Game Over в начале
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
        SceneManager.LoadScene("MainMenu");
    }
}
