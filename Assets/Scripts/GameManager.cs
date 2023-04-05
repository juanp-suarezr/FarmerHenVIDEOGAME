using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    
    public GameObject character;

    public GameObject gallinas;

    public GameObject portada;

    public corral corral;
    public GameObject GameWin;
    public GameObject GameOver;

    //instancia objeto tipo timer
    public timer timerScript;
    
    //time y rango de espacio para crear gallina
    public float createTime = 0f, createRange = 12f;

    //contador tutorial
    public int tutorialcount;

    //num gallinas segun nivel
    private int num_gallinas;
    //num tiempo segun nivel
    private float num_time;

    private int num_escena;

    //mobile ajust
    public bool ismobile = true;

    void Start()
    {
        Time.timeScale = 1f;
        //posicion inicial del personaje principal
        character.transform.position = new Vector3(-7, -2, 0);

        if (SceneManager.GetActiveScene().name == "tutorial")
        {
            timerScript.SetTime(0);
            character.transform.position = new Vector3(4, -2, 0);
            
            

        } else {
        
            switch (SceneManager.GetActiveScene().name)
            {
                
                case "Level1":
                    num_escena = 3;
                    portada.SetActive(true);
                    num_gallinas = 10;
                    num_time = 0;
                    
                break;

                case "Level2":
                    num_escena = 4;
                    portada.SetActive(true);
                    num_gallinas = 12;
                    num_time = 0;
                    
                break;

                case "Level3":
                    num_escena = 5;
                    portada.SetActive(true);
                    num_gallinas = 12;
                    num_time = 0;
                    
                break;
            }

            character.transform.position = new Vector3(-7, -2, 0);

            //posicion random gallina
            for (int i = 0; i < num_gallinas; i++)
                {
                    InvokeRepeating ("Creando", -3f, createTime);
                }
        }

        
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timerScript.isTimeOver) 
            {
                Time.timeScale = 0f;
                GameOver.SetActive(true);
            } else
            {
                GameOver.SetActive(false);
            }

        if (num_gallinas == corral.resultado)
            {
                Time.timeScale = 0f;
                GameWin.SetActive(true);
            } else {
                GameWin.SetActive(false);
            }
        
        if (Input.touchCount > 0) 
        {
            ismobile = true;
        } else
        {
            ismobile = false;
        }
    }

    public void Creando() 
    {
        Vector3 spawnPosition = new Vector3 (0,0,0);
        spawnPosition = this.transform.position + Random.onUnitSphere * createRange;
        spawnPosition = new Vector3 (spawnPosition.x, spawnPosition.y, 0);

        GameObject gallina = Instantiate (gallinas, spawnPosition, Quaternion.identity);

    }

    public void ContinuegameBtn()
    {
        portada.SetActive(false);
        Time.timeScale = 1f;
        switch (num_escena)
            {
                
                case 3:
                    num_time = 60;
                    timerScript.SetTime(num_time);
                break;

                case 4:
                    num_time = 30;
                    timerScript.SetTime(num_time);
                break;

                case 5:
                    num_time = 20;
                    timerScript.SetTime(num_time);
                break;
            }
        

    }

    public void NextLevelBtn()
    {
        SceneManager.LoadScene(num_escena+1);
        
        

    }


}
