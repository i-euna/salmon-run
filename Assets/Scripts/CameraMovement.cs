using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public static CameraMovement instance;
    public Transform player;

    private void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(player != null)
            transform.position = new Vector3(player.transform.position.x + 3, player.transform.position.y + 3, transform.position.z) ;
    }
}
