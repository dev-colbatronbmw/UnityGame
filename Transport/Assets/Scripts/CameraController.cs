using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform player;

    private void Update()
    {
        float lockHigh = player.position.y + 2;

        transform.position = new Vector3(player.position.x, lockHigh, transform.position.z);

    }


}
