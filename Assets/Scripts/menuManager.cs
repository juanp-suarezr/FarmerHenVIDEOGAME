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
    
    //scene home
    public void PlayGame() 
    {
        Time.timeScale = 1f;
        if (SceneManager.GetActiveScene().name == "Home")
        {
            SceneManager.LoadScene(1);
        } else if (SceneManager.GetActiveScene().name == "Home 1")
        {
            SceneManager.LoadScene(2);
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
            pauseMenu.SetActive(true);
            UpdateGameState();
        }
        

    }

    public void ContinueMenuBtn()
    {
        if (isPaused) {
            continueBtn.SetActive(true);
            Debug.Log("continuoWorks");
            isMenuPause = false;
            pauseMenu.SetActive(false);
            portada.SetActive(false);
            UpdateGameState();

        } else {
            Debug.Log("continuoWorksOutIf");
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
