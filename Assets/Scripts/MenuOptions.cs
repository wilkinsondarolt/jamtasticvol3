using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuOptions : MonoBehaviour {

    public void LoadScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
