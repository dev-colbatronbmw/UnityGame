using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{

    [SerializeField] private string sceneToLoad;
    public bool isDoorOpen = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            if (isDoorOpen)
            {
                SceneManager.LoadScene(sceneToLoad);

            }

          



        }



    }
}
