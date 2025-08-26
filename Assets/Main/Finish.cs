using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    [SerializeField] private GameObject _finishPanel;
    private bool _isFinished = false;

    private void Start()
    {
        if (_finishPanel != null)
            _finishPanel.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_isFinished)
            return;

        if (other.CompareTag("Player"))
        {
            _isFinished = true;

            if (_finishPanel != null)
                _finishPanel.SetActive(true);

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
