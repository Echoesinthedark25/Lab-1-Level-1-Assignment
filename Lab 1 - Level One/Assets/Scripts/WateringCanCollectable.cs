using UnityEngine;
using UnityEngine.SceneManagement;

public class WateringCanCollectable : MonoBehaviour
{

    public static int NumberCollected = 0;

    public ButtonLoadScene buttonLoadScene;

    private void OnTriggerEnter2D(Collider2D collider2d)
    {
        if (collider2d.gameObject.CompareTag("Player") == true)
        {
            NumberCollected += 1;
            Debug.Log($"Watering cans collected: {NumberCollected}");
            
            this.gameObject.SetActive(false);

            

        }

        if (NumberCollected >= 1)
        {
            Scene ButtonLoadScene = SceneManager.GetActiveScene();

            SceneManager.LoadScene(ButtonLoadScene.buildIndex);
        }

    }
}
