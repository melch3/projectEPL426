using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadMenuScript : MonoBehaviour
{
    public string nextSceneName;
    public float delay = 10f;

    void Start()
    {
        Invoke("LoadNextScene", delay);
    }
    void LoadNextScene()
    {
        SceneManager.LoadScene(nextSceneName);
    }
}
