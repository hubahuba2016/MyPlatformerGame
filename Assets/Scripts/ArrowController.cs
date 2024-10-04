using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    public GameObject player;
    public Rigidbody2D arrow_rb;
    public PlayerController player_script;
    public bool facingRight;
    public GameObject[] arrows;
    public int i;
    public int arrowlength;
    // Start is called before the first frame update
    void Start()
    {
        if(GameObject.Find("Player")!=null)
        {    
        player = GameObject.Find("Player");
        if(transform.position.x>player.transform.position.x)
        {
            arrow_rb.velocity= new Vector2(-5, 0);
            if(facingRight==false)
            {
                Flip();
            }
        }
        if(transform.position.x<player.transform.position.x) 
        {
            arrow_rb.velocity= new Vector2(5, 0);
            if(facingRight==true)
            {
                Flip();
            }
        }
        player_script = player.GetComponent<PlayerController>();
        i = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.Find("Player")!=null)
        {
        if(player.transform.position.x-transform.position.x>10||player.transform.position.x-transform.position.x<-10)
        {
            Destroy(this.gameObject);
        }
        }
        arrows = GameObject.FindGameObjectsWithTag("Arrow");
        arrowlength = arrows.Length;
        while(i<arrows.Length)
        {
            Destroy(arrows[i].gameObject);
            i++;
        }
        
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.name=="Player")
        {
            player_script.health = player_script.health-100;
            Destroy(this.gameObject);
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
