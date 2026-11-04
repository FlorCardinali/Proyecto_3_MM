using TMPro;
using UnityEngine;

public class ControladorTextoHormiga : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI texto;

    public void CambiarTexto(string nuevoTexto)
    {
        if (texto != null)
            texto.text = nuevoTexto;
    }

    public void LimpiarTexto()
    {
        if (texto != null)
            texto.text = "";
    }
}