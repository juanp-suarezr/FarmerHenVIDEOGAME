using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gallina : MonoBehaviour
{
    private Rigidbody2D rb;
    Vector2 input;

    [SerializeField] private AudioClip sonidoHen;

    
    //variable de movimiento
    public float speed;
    
    public GameManager gameManager;

    public float minimoX, minimoY;
    public float maximoX, maximoY;

    public SpriteRenderer Spr;
    //var para instanciar la animacion
    private Animator animator;

    public GameObject gallinas;
    
    //character
    public GameObject target;

    public int rutina;
    public int direccion;
    
    public float cronometro = 0;

    // Start is called before the first frame update
    void Start()
    {
         rb = GetComponent<Rigidbody2D>();
        
        
        
        animator = GetComponent<Animator>();

        
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minimoX, maximoX), Mathf.Clamp(transform.position.y, minimoY, maximoY), transform.position.z);
        Comportamientos();
        
    }

    

    private void OnCollisionEnter2D(Collision2D other)
    {
        
        

        if (other.gameObject.tag == "Player")
        {
        SoundController.Instance.EjecutarSonido(sonidoHen);
        Destroy(gallinas,.0f);
        
    } 
        

        // if (transform.position.x < target.transform.position.x) {
        //         Spr.flipX = false;
        //         input.x = transform.position.x-0.5f;
        //         input.y = transform.position.y;
        //         animator.SetBool("run", true);
        //         transform.position = input;
                
        //     } else if (transform.position.x > target.transform.position.x) {
        //         Spr.flipX = true;
        //         input.x = transform.position.x+0.5f;
        //         input.y = transform.position.y;
        //         animator.SetBool("run", true);
        //         transform.position = input;
                
        //     } else if (transform.position.y > target.transform.position.y) {
                
        //         input.x = transform.position.x;
        //         input.y = transform.position.y+0.5f;

        //         transform.position = input;
                
        //     } else if (transform.position.y < target.transform.position.y) {
                
        //         input.x = transform.position.x;
        //         input.y = transform.position.y-0.5f;

        //         transform.position = input;
        //         animator.SetBool("run", true);
                
        //     }
            

    }

    public void Comportamientos() {

        animator.SetBool("run", true);
        cronometro += 1 * Time.deltaTime;

        if (cronometro >= 1.5) 
        {
            rutina = Random.Range(0,2);
            cronometro = 0;
        }

        switch (rutina)
            {
                case 0:
                    animator.SetBool("run", false);
                    break;

                case 1:
                    direccion = Random.Range(0, 4);
                    rutina++;
                    break;

                case 2:

                    switch (direccion)
                    {
                        case 0:
                            
                            transform.rotation = Quaternion.Euler(0, 0, 0);
                            transform.Translate(Vector3.right * speed * Time.deltaTime);
                            break;

                        case 1:
                            
                            transform.rotation = Quaternion.Euler(0, 180, 0);
                            transform.Translate(Vector3.right * speed * Time.deltaTime);
                            break;
                        case 2:
                            
                            transform.rotation = Quaternion.Euler(0, 0, 0);
                            transform.Translate(Vector3.up * speed * Time.deltaTime);
                            break;

                        case 3:
                            
                            transform.rotation = Quaternion.Euler(0, 0, 0);
                            transform.Translate(Vector3.down * speed * Time.deltaTime);
                            break;
                    }
                    animator.SetBool("run", true);
                    break;
            }

    }

    

    

    

}