using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuOptions : MonoBehaviour {

    public void StartGame(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }
}
