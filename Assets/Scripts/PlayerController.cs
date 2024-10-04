using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    public Rigidbody2D player_rigidbody;
    public Animator player_animator;
    public float run_speed = 1f;
    public bool is_grounded;
    public bool facingRight = true;
    public float jump_force = 10f;
    public float dash_time = 2f;
    public string ground_name;
    public float health = 1000f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            MoveLeft();
        }
        if (Input.GetKey(KeyCode.D))
        {
            MoveRight();
        }
        if(player_rigidbody.velocity.x>0.1)
        {
            if(facingRight==false)
            {
                Flip();
            }
        }
        else if(player_rigidbody.velocity.x < -0.1)
        {
            if(facingRight==true)
            {
                Flip();
            }
        }
        if(Input.GetKeyUp(KeyCode.A)&&Input.GetKeyUp(KeyCode.D)&&is_grounded==true)
        {
             player_animator.Play("Player Idle");   
        }
        if(Input.GetKeyDown(KeyCode.Space)&&is_grounded==true)
        {
            Jump();
        }
        if(is_grounded==false)
        {
            if(player_rigidbody.velocity.y>0)
            {
                player_animator.Play("Player Jump");
            }
            else if(player_rigidbody.velocity.y<0)
            {
                player_animator.Play("Player Fall");
            }
        }
        if(dash_time<2)
        {
            dash_time = dash_time+0.1f;
        }
       
        if(health<=0)
        {
            Destroy(this.gameObject);
        }
        if(transform.position.y<-50)
        {
            Destroy(this.gameObject);
        }
    }
    
    void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Ground")
        {
            is_grounded = true;
            ground_name = collision.gameObject.name;
        }
        
{
    //your code here
}
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Ground")
        {
            is_grounded = false;
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
    public void MoveLeft()
    {
        player_rigidbody.velocity = new Vector2(-1*run_speed,player_rigidbody.velocity.y);
            if(is_grounded)
            {if(!player_animator.GetCurrentAnimatorStateInfo(0).IsName("Player Dash"))
                {
                    player_animator.Play("Player Run");
                }
                if(Input.GetKey(KeyCode.LeftShift) && dash_time>0f)
                {
                    Dash();
                }  
                
            }
    }
    public void MoveRight()
    {
        player_rigidbody.velocity = new Vector2(1*run_speed,player_rigidbody.velocity.y);
            if(is_grounded)
            {
                if(!player_animator.GetCurrentAnimatorStateInfo(0).IsName("Player Dash"))
                {
                    player_animator.Play("Player Run");
                }
                if(Input.GetKey(KeyCode.LeftShift) && dash_time>0f)
                {
                   Dash();
                }   
            } 
    }
    public void Dash()
    {
        if(player_rigidbody.velocity.x<-0.1)
        {
            player_rigidbody.velocity = new Vector2(-2*run_speed,player_rigidbody.velocity.y);
            player_animator.Play("Player Dash");
            dash_time = dash_time - 0.2f;
        }
        if(player_rigidbody.velocity.x>0.1)
        {
            player_rigidbody.velocity = new Vector2(2*run_speed,player_rigidbody.velocity.y);
            player_animator.Play("Player Dash");
            dash_time = dash_time - 0.2f;
        }
    }
    public void Jump()
    {
        if(is_grounded==true)
        {
            player_rigidbody.AddForce(new Vector2(0,jump_force),ForceMode2D.Impulse);
        }
    }
    public void Idle()
    {
        player_rigidbody.velocity = new Vector2(0,player_rigidbody.velocity.y);
    }
}
