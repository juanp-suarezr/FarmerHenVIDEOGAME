using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{

    public static SoundController Instance;

    private AudioSource soundHen;

    private void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else 
        {
            Destroy(gameObject);
        }

        soundHen = GetComponent<AudioSource>();
    }

    public void EjecutarSonido(AudioClip sonido) {
        soundHen.PlayOneShot(sonido);

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
