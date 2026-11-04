using UnityEngine;
using TMPro;
using System;
public class PuntoDeInteres : MonoBehaviour
{
    [Header("Nombre del Punto de Interés")]
    public TextMeshProUGUI nombrePunto;
    public string nombrePuntoDeInteres;
    private void Start()
    {
        if (nombrePunto != null)
        {
            nombrePunto.text = nombrePuntoDeInteres;
        }
    }
}
