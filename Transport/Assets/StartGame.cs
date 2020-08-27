using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartGame : MonoBehaviour
{


    [SerializeField] private string sceneToLoad;
   
    private void Update()
    {

        if (Input.anyKey)
        {
         
                SceneManager.LoadScene(sceneToLoad);

            }


    }
}
