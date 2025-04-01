using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    private string currentSceneName;
    public void ChangeScene(string name)
    {
        currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
