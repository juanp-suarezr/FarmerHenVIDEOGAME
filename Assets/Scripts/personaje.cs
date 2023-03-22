using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GG.Infrastructure.Utils.Swipe;

public class personaje : MonoBehaviour
{
    private Rigidbody2D rb;
    Vector2 input;
    
    //touch
    Vector2 Touchmove = Vector2.zero;
    public Transform playerTransform;

    public float touchSpeed;

    //variable de movimiento
    public float speed;
    public float dirX;
    public float dirY;

    public float minimoX, minimoY;
    public float maximoX, maximoY;

    public GameObject gallina;

    public corral corral;

    public int num_gallinas = 1;

    public SpriteRenderer Spr;
    //var para instanciar la animacion
    public Animator animator;
    // Start is called before the first frame update
    
    

    

    
    
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
        

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            float screenHalf = Screen.width / 2;
            float screenHalfY = Screen.height / 2;
            Debug.Log(touch.position.x);
            if (touch.position.x > playerTransform.position.x ) {
                Debug.Log("entro");
                Spr.flipX = false;
                Touchmove = Vector2.right;
            } else if (touch.position.x < 0) {
                Spr.flipX = true;
                Touchmove = Vector2.left;
            } else if (touch.position.y < 0) {
                
                Touchmove = Vector2.down;
            } else if (touch.position.y > 0) {
                
                Touchmove = Vector2.up;
            }

            
        } else 
        {
            dirX = Input.GetAxis("Horizontal");
            dirY = Input.GetAxis("Vertical");
            input.x = dirX;
            input.y = dirY;
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
        
        if (Input.touchCount > 0)
        {
            rb.velocity = Touchmove * touchSpeed * Time.fixedDeltaTime;
        } else 
        {
            rb.velocity = input * speed * Time.fixedDeltaTime;
        }
        

        
    }

    private void OnCollisionEnter2D(Collision2D other) {
        
        if (other.gameObject.tag == "gallina")
        {

            corral.contador +=1;
            
            
            
        }
        
    }
    
}
