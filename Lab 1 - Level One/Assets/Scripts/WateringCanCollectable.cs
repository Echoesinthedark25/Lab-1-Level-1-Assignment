using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class WateringCanCollectable : MonoBehaviour
{

    public int NumberCollected = 0;

    public LevelExit levelExit;

    public UnityEvent levelDone;

    //public ButtonLoadScene buttonLoadScene;

    //public GameObject UITrigger = GameObject.Find("EndLevelUI");

    private void OnTriggerEnter2D(Collider2D collider2d)
    {
        if (collider2d.gameObject.CompareTag("Player") == true)
        {
            NumberCollected += 1;
            Debug.Log($"Watering cans collected: {NumberCollected}");
            
            this.gameObject.SetActive(false);

            

        }

        //if (NumberCollected >= 1)
        {
            
            
            
            
            //UITrigger.SetActive(true);
            
            
            
            //Scene ButtonLoadScene = SceneManager.GetActiveScene();

            //SceneManager.LoadScene(ButtonLoadScene.buildIndex);
        }

    }

    public void LevelDone()
    {
        levelDone.Invoke();
    }
}
