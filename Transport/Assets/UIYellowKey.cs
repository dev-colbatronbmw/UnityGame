using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIYellowKey : MonoBehaviour
{
    public float filler;
    public Image key;

    // Start is called before the first frame update
    void Start()
    {
        GameObject green = GameObject.Find("Green");
        PlayerController playerController = green.GetComponent<PlayerController>();

        filler = playerController.yellowKey;



        key = GetComponent<Image>();

    }

    // Update is called once per frame
    void Update()
    {
        GameObject green = GameObject.Find("Green");
        PlayerController playerController = green.GetComponent<PlayerController>();

        filler = playerController.yellowKey;

        key.fillAmount = filler;


    }
}
