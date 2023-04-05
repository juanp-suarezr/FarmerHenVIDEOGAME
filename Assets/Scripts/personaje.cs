using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GG.Infrastructure.Utils.Swipe;

public class personaje : MonoBehaviour
{
    private Rigidbody2D rb;
    Vector2 input;
    
    //touch
    Vector2 Touchmove;
    public Transform playerTransform;

    public float touchSpeed;

    //variable de movimiento
    public float speed;
    public float dirX;
    public float dirY;

    public float dirXM;
    public float dirYM;

    
    public GameObject gallina;

    public corral corral;

    public int num_gallinas = 1;

    public SpriteRenderer Spr;
    //var para instanciar la animacion
    public Animator animator;
    // Start is called before the first frame update
    
    //mobile ajust
    public menuManager menuManager;

    public GameManager GameManager;

    public int num;

    public CharacterController controller;


    

    
    
    void Start()
    {
        //getters

        rb = GetComponent<Rigidbody2D>();
        
        animator = GetComponent<Animator>();

        
    }

    // Update is called once per frame
    void Update()
    {
        //acepta input usuario verti y horiz
                    
                
                

                switch (num)
                {
                    
                    case 1: 
                        dirX = 0;
                        dirY += 0.03f;
                        input.x = dirX;
                        input.y = dirY;
                        
                    break;
                    case 2: 
                        dirX = 0;
                        dirY -= 0.03f;
                        input.x = dirX;
                        input.y = dirY;
                        
                    break;
                    case 3: 
                        Spr.flipX = false;
                        dirX -= 0.03f;
                        dirY = 0;
                        input.x = dirX;
                        input.y = dirY;
                        
                    break;
                    case 4: 
                        Spr.flipX = true;
                        dirX += 0.03f;
                        dirY = 0;
                        input.x = dirX;
                        input.y = dirY;
                        
                    break;

                    default:
                    dirX = Input.GetAxis("Horizontal");
                    dirY = Input.GetAxis("Vertical");
                    input.x = dirX;
                    input.y = dirY;
                    
                break;
                }
            
            
            
        

        if (dirX != 0 || dirY != 0) {

            

            // transform.position = new Vector3(Mathf.Clamp(transform.position.x, minimoX, maximoX), Mathf.Clamp(transform.position.y, minimoY, maximoY), transform.position.z);

            if (corral.contador > 0)
            {
                
                animator.SetBool("withHen", true);
                animator.SetBool("moving", false);
                animator.SetBool("withHenStop", false);
                
            } else {
                animator.SetBool("withHen", false);
                animator.SetBool("moving", true);
            }

            //right
            if (dirX > 0) {
                Spr.flipX = false;
                
                
            //left
            } else if (dirX < 0) {
                Spr.flipX = true;
                
                
            } else if (dirY > 0 || dirY < 0) {
                
            }


        } else {

            if (corral.contador > 0)
            {
                
                animator.SetBool("withHenStop", true);
                animator.SetBool("withHen", false);
                
            } else {
                animator.SetBool("moving", false);
            }

            
        }
        
        
        
    }

    private void FixedUpdate() {
        
       
            
       
            rb.velocity = input * speed * Time.fixedDeltaTime;
        
            

            
        
        

        
    }

    private void OnCollisionEnter2D(Collision2D other) {
        
        if (other.gameObject.tag == "gallina")
        {

            corral.contador +=1;
            
            
            
        }
        
    }


    //botones mobile

    public void animationWithHen() 
    {
        if (dirXM != 0 || dirYM != 0) {

            if (corral.contador > 0)
            {
                
                animator.SetBool("withHen", true);
                animator.SetBool("moving", false);
                animator.SetBool("withHenStop", false);
                
            } else {
                animator.SetBool("withHen", false);
                animator.SetBool("moving", true);
            }

            
        } else {

            if (corral.contador > 0)
            {
                
                animator.SetBool("withHenStop", true);
                animator.SetBool("withHen", false);
                
            } else {
                animator.SetBool("moving", false);
            }

            
        }
    }
    public void Up() {
        
        animationWithHen();
        num = 1;
        
        
        
    }

    public void Down() {
        
        animationWithHen();
        num = 2;
        
    }

    public void Left() {
        
        animationWithHen();
        num = 3;
        
    }

    public void Right() {
        
        animationWithHen();
        num = 4;
        
    }

    public void stop() {
        num = 0;
    }
    
}
