using UnityEngine;
using UnityEngine.Events;

public class LevelExit : MonoBehaviour
{

    public int ExitsReached = 0;

    public WateringCanCollectable wateringCanCollectable;

    public ButtonLoadScene buttonLoadScene;

    

    public GameObject UITrigger;


    private void Start()
    {
        //UITrigger = GameObject.Find("EndLevelUI");
    }


    private void OnTriggerEnter2D(Collider2D collider2d)
    {
        if (collider2d.gameObject.CompareTag("Player") == true)
        {
            ExitsReached += 1;
            Debug.Log($"Exits Reached: {ExitsReached}");


           


        }

        

        if (ExitsReached >= 1)
        {




            UITrigger.SetActive(true);



            //Scene ButtonLoadScene = SceneManager.GetActiveScene();

            //SceneManager.LoadScene(ButtonLoadScene.buildIndex);
        }

    }

    



}
