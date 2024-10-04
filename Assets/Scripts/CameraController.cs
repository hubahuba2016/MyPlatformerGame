using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.Find("Player")!=null)
        {
            transform.position = new Vector3(player.transform.position.x+3, player.transform.position.y-2, -10);
        }
    }
}
