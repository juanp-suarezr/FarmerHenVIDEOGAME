using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class corral : MonoBehaviour
{

    public bool characterIstouching = false;
    public personaje personaje;
    private Rigidbody2D rb;

    public int contador;
    public int resultado;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other) {
         if (other.gameObject.tag == "Player") {
            characterIstouching = true;
            Debug.Log(contador);
            if (contador != 0)
            {
                resultado += contador;
                contador = 0;
                Debug.Log("gallina atrapada");
                Debug.Log("resultado: " +resultado);
                
                
            }
         }
    }

    private void OnCollisionExit2D(Collision2D other) {
        personaje.animator.SetBool("withHen", false);
        personaje.animator.SetBool("moving", true);
    }
}
