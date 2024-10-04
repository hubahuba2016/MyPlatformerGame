using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class GroundController : MonoBehaviour
{
    public bool ground_spawned = false;
    public GameObject player;
    public GameObject ground;
    public GameObject enemy;
    public Vector3 position;
    public float floatx;
    public float floaty;
    public int enemy_spawn_number;
    public bool occupy_ground;
    // Start is called before the first frame update
    void Start()
    {
        ground_spawned=false;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.Find("Player")!=null)
        {
        if(player.transform.position.x-this.transform.position.x>5&& ground_spawned==false)
        {
            ground_spawned= true;
            floatx = transform.position.x+ UnityEngine.Random.Range(22f,25f);
            floaty = transform.position.y + UnityEngine.Random.Range(-2.5f,2.5f);
            position = new Vector3(floatx,floaty,0f);
            Instantiate(ground,position,quaternion.identity);
            occupy_ground = true;
           
        }
        if(occupy_ground==true)
        {
            enemy_spawn_number = UnityEngine.Random.Range(1,3);
            while(enemy_spawn_number>0)
            {
                Instantiate(enemy,position+new Vector3(UnityEngine.Random.Range(-5,5),5f,0),quaternion.identity);
                enemy_spawn_number=-1;
            }
            if(enemy_spawn_number<=0)
            {
                occupy_ground= false;
            }
        }
        if(player.transform.position.x-this.transform.position.x>25)
        {
            Destroy(this.gameObject);
        }
        }
    }
}
