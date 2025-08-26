using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    [SerializeField] private GameObject _finishPanel;
    private bool _isFinished = false;

    private void OnTriggerEnter(Collider other)
    {
        if (_isFinished)
            return;

        if (other.CompareTag("Player"))
        {
            _isFinished = true;
            HandleFinish();
        }
    }

    private void HandleFinish()
    {
        SceneManager.LoadScene("VictoryScene");
    }
}
