using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class puntaje : MonoBehaviour
{
    public corral corral; 
    private int puntos;
    private TextMeshProUGUI textMesh;

    private void Start() {
        textMesh = GetComponent<TextMeshProUGUI>();
    }

    private void Update() {
        puntos = corral.resultado;
        textMesh.text = puntos.ToString("0");
    }
}
