using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuManager : MonoBehaviour
{

    

    bool isMenuPause = false;

    public bool isPaused;

    public GameObject pauseMenu;
    public GameObject pauseBtn;
    public GameObject continueBtn;

    public GameObject portada;

    //mobile ajust

    
    public GameManager GameManager;

    public dialogueManager dialogueManager;

    public MobileControler MobileControler;

    public int num = 0;

    public GameObject botonesM;

    public personaje personaje;

    
    //scene home
    public void PlayGame() 
    {
        Time.timeScale = 1f;
        

        if (SceneManager.GetActiveScene().name == "Home")
        {
            SceneManager.LoadScene(1);
            
        } else if (SceneManager.GetActiveScene().name == "Home 1")
        {
            if (dialogueManager.cronometro <= 0)
                {

                    
                    dialogueManager.NextDialogueLine();
                    num += 1;
                    if (num == 3)
                    {
                        SceneManager.LoadScene(2);
                    }
                    
                } else {
                    dialogueManager.cronometro -= Time.deltaTime;
                }

            
            
            

        }
        
    }

    

    public void ExitGame() 
    {
        
        Application.Quit();
    }

    //scene game
    public void PauseMenuBtn()
    {
        if (isPaused) {
            isMenuPause = false;
            pauseMenu.SetActive(false);
            
            UpdateGameState();

        } else {
            isMenuPause = true;
            GameManager.GameWin.SetActive(false);
            GameManager.GameOver.SetActive(false);
            pauseMenu.SetActive(true);
            
            portada.SetActive(false);
            UpdateGameState();
        }
        

    }

    public void ContinueMenuBtn()
    {
        if (dialogueManager.Dialogueistrue)
        {
                isMenuPause = false;
                pauseMenu.SetActive(false);
                portada.SetActive(false);
                UpdateGameState();
        }

        if (isPaused) {
            
            isMenuPause = false;
            pauseMenu.SetActive(false);
            portada.SetActive(false);
            UpdateGameState();

        } else {
            UpdateGameState();
        }
        

    }

    public void Reiniciar() 
    {
        Time.timeScale = 1f;
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ExitBtnLevel() 
    {
        
        SceneManager.LoadScene(0);
    }

    private void Update() {
        
        if (Input.GetKeyDown(KeyCode.Escape) && isMenuPause)
        {
            isMenuPause = false;
            pauseMenu.SetActive(false);
            
            UpdateGameState();
        } else if (Input.GetKeyDown(KeyCode.Escape)) {
            isMenuPause = true;
            pauseMenu.SetActive(true);
            
            UpdateGameState();
        }

        
    }

    private void UpdateGameState() 
    {
        isPaused = !isPaused;

        if (isPaused) {
            Time.timeScale = 0f;
            pauseBtn.SetActive(false);
            

        } else {
            Time.timeScale = 1f;
            pauseBtn.SetActive(true);
            
        }
    }

    


}
