using UnityEngine;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour
{
    public KeyCode ResetKey = KeyCode.R;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) == true)
        {
            Scene currentScene = SceneManager.GetActiveScene();
            
            SceneManager.LoadScene(currentScene.buildIndex);
        }
    }
}
