using UnityEngine;
using UnityEngine.SceneManagement;


public class ButtonLoadScene : MonoBehaviour
{
    //public WateringCanCollectable wateringCanCollectable;
    public LevelExit levelExit;

    public string sceneToLoad;

    //public void LoadScene()
    //{
        //SceneManager.LoadScene(sceneToLoad);
    //}

    public void LoadScene(string sceneToLoad)
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
