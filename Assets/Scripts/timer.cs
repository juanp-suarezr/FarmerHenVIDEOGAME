using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class timer : MonoBehaviour
{

    
    public animTimer animTimer;
    private float time;
    private TextMeshProUGUI textMesh;

    public bool isTimeOver = false;


    // Start is called before the first frame update
    void Start()
    {
        
        textMesh = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (time <= 0)
        {
            if (time < 0) 
            {
                isTimeOver = true;
            }
            
            animTimer.animator.SetBool("time", false);

        } else {
            time -= Time.deltaTime;
            textMesh.text = time.ToString("0");
            animTimer.animator.SetBool("time", true);
        }
        
    }

    public float GetTime() {
        return time;
    }

    public void SetTime(float value) {
        time = value;
    }
}
