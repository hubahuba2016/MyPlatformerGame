using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public string ground_name;
    public PlayerController player_script;
    public GameObject player;
    public Rigidbody2D enemy_rb;
    public bool facingRight;
    public float health = 100f;
    public Animator enemy_animtr;
    public GameObject arrow;
    public bool arrow_launch;
    public GameObject[] arrows;
    public WorldController world_script;
    public GameObject world;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        player_script= player.GetComponent<PlayerController>();
        world = GameObject.Find("World");
        world_script = world.GetComponent<WorldController>();
    }

    // Update is called once per frame
    void Update()
    {
        arrows = GameObject.FindGameObjectsWithTag("Arrow");
        if(GameObject.Find("Player")!=null)
        {
        if(player_script.ground_name==ground_name)
        {
            if(player_script.gameObject.transform.position.x<transform.position.x&&arrows.Length==0)
            {
                enemy_animtr.Play("Soldier Arrow Attack");
                if(facingRight==false)
                {
                    Flip();
                }
            }
            if(player_script.gameObject.transform.position.x>transform.position.x&&arrows.Length==0)
            {
                enemy_animtr.Play("Soldier Arrow Attack");
                if(facingRight==true)
                {
                    Flip();
                }
            }
        }
        }
        if(arrow_launch==true)
        {
            Instantiate(arrow,transform.position,quaternion.identity);
            arrow_launch= false;
        }
        if(health<0)
        {
            Destroy(this.gameObject);
        }
        if(arrows.Length!=0)
        {
            enemy_animtr.Play("Soldier Idle");
        }
    }
    void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Ground")
        {
            ground_name = collision.gameObject.name;
        }
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.name=="Player")
        {
            world_script.score+=1;
            Destroy(this.gameObject);
        }
    }
    void OnTriggerStay2D(Collider2D collider)
    {
        if(collider.name == "Player")
        {
            if(collider.transform.position.x<transform.position.x)
            {
                if(facingRight==false)
                {
                    Flip();
                }
                enemy_rb.velocity = new Vector2(-3,enemy_rb.velocity.y);
            } 
            if(collider.transform.position.x>transform.position.x)
            {
                if(facingRight==true)
                {
                    Flip();
                }
                enemy_rb.velocity = new Vector2(3,enemy_rb.velocity.y);
            }
        }
    }

    void Flip()
    {
        // Switch the way the player is labelled as facing
        facingRight = !facingRight;
        // Multiply the player's x local scale by -1
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
