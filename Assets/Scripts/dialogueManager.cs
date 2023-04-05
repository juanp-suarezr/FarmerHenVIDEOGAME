using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class dialogueManager : MonoBehaviour
{

    
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField, TextArea(4,6)] private string[] dialogueLines;
    private float typingTime = 0.05f;
    public bool Dialogueistrue;
    private int lineIndex;
    
    public float cronometro = 5;

    public corral corral;

    public GameObject gallina;

    public GameManager gameManager; 

    public personaje personaje;
        

    private void StartDialogue()
    {
        Dialogueistrue = true;
        dialoguePanel.SetActive(true);
        lineIndex = 0;
        StartCoroutine(ShowLine());
    }

    public void NextDialogueLine() {
        lineIndex++;
        cronometro = 6;
        Debug.Log(lineIndex);
        if (lineIndex < dialogueLines.Length)
        {
            StartCoroutine(ShowLine());
        } else {
            Dialogueistrue = false;
            dialoguePanel.SetActive(false);
        }
    }

    //corrutina
    private IEnumerator ShowLine() 
    {
        dialogueText.text = string.Empty;

        foreach (char letter in dialogueLines[lineIndex])
        {
            Debug.Log(dialogueText.text);
            dialogueText.text += letter;
            yield return new WaitForSecondsRealtime(typingTime);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Home 1")
        {
            if (cronometro <= 0)
                {

                    
                    if (Input.GetKeyDown(KeyCode.Return)) 
                    {
            
                        NextDialogueLine();
                    }
                    
                } else {
                    cronometro -= Time.deltaTime;
                }
            
        } else if (SceneManager.GetActiveScene().name == "tutorial")
        {
            if (gameManager.tutorialcount == 0)
            {
                if (cronometro <= 0)
                {

                    
                    if (Input.GetKeyDown(KeyCode.LeftArrow) || personaje.num == 3)
                    {
                        NextDialogueLine();
                        gameManager.tutorialcount += 1;
                    }

                    if (Input.GetKeyDown(KeyCode.RightArrow) || personaje.num == 4)
                    {
                        NextDialogueLine();
                        gameManager.tutorialcount += 1;
                    }
                    
                } else {
                    cronometro -= Time.deltaTime;
                }
                
                
            } else if (gameManager.tutorialcount == 1)
            {
                
                if (cronometro <= 0)
                {
                    
                    
                    if (Input.GetKeyDown(KeyCode.UpArrow) || personaje.num == 1)
                    {
                        NextDialogueLine();
                        gameManager.tutorialcount += 1;
                    }

                    if (Input.GetKeyDown(KeyCode.DownArrow) || personaje.num == 2)
                    {
                        NextDialogueLine();
                        gameManager.tutorialcount += 1;
                    }
                    
                } else {
                    cronometro -= Time.deltaTime;
                }
                
            } else if (gameManager.tutorialcount == 2)
            {   
                gallina.SetActive(true);
                
                if (cronometro <= 0)
                {
                    
                    if (corral.characterIstouching)
                    {
                        NextDialogueLine();
                        gameManager.tutorialcount += 1;
                    }

                    
                } else {
                    cronometro -= Time.deltaTime;
                }
                
            } else if (gameManager.tutorialcount == 3)
            {   
                gallina.SetActive(true);
                
                if (cronometro <= 0)
                {
                    if (Input.GetKeyDown(KeyCode.Return) || Input.touchCount > 0) 
                    {
                        Dialogueistrue = false;
                        SceneManager.LoadScene(3);
                    }
                    

                    
                } else {
                    cronometro -= Time.deltaTime;
                }
                
            }
            
        }
        
        
    }

    void Start() {
        if (!Dialogueistrue)
            {
                StartDialogue();
                Debug.Log(dialogueText.text);
                Debug.Log(dialogueLines[lineIndex]);
            } else if (dialogueText.text == dialogueLines[lineIndex])
            {
                NextDialogueLine();
            } else {
                StopAllCoroutines();
                dialogueText.text = dialogueLines[lineIndex]; 
            }
    }
    
    
}
