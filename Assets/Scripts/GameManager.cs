using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instancia { get; private set; }

    [Header("Zonas")]
    public Transform zonaPulgón;

    [Header("Larvas")]
    public Transform zonaLarvas;
    public GameObject prefabCaca;
    public float intervaloCacaLarvas = 12f;
    public float intervaloLarvasMin = 45f;
    public float intervaloLarvasMax = 70f;


    [Header("Reina")]
    public float intervaloReinaMin = 45f;
    public float intervaloReinaMax = 70f;

    [Header("Granja")]
    public float intervaloGranjaMin = 18f;
    public float intervaloGranjaMax = 30f;



    [Header("Prefabs")]
    public GameObject prefabComida;
    public GameObject prefabAgua;

    // ===== Estados =====
    public bool ReinaPideComida { get; private set; }
    public bool ReinaPideAgua { get; private set; }
    public bool LarvasNecesitanCarinio { get; private set; }

    private int almacenComida = 0;

    void Awake()
    {
        if (Instancia == null) Instancia = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        StartCoroutine(CicloReina());
        StartCoroutine(CicloCacaLarvas());
        StartCoroutine(CicloLarvas()); 
        StartCoroutine(CicloPulgón());
    }
    IEnumerator CicloReina()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(intervaloReinaMin, intervaloReinaMax)); 

            if (Random.value > 0.5f)
                ReinaPideComida = true;
            else
                ReinaPideAgua = true;
        }
    }

    IEnumerator CicloLarvas()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(intervaloLarvasMin, intervaloLarvasMax));
            LarvasNecesitanCarinio = true;
        }
    }

    IEnumerator CicloCacaLarvas()
    {
        while (true)
        {
            yield return new WaitForSeconds(intervaloCacaLarvas);

            Vector3 pos = zonaLarvas.position + Random.insideUnitSphere * 1.05f;
            pos.y = 0.1f;

            GameObject caca = Instantiate(prefabCaca, pos, Quaternion.identity);
            caca.tag = "Caca";
        }
    }

    IEnumerator CicloPulgón()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(intervaloGranjaMin, intervaloGranjaMax));
            Vector3 pos = zonaPulgón.position + Random.insideUnitSphere * 1.2f;
            pos.y = 0.1f;
            GameObject comida = Instantiate(prefabComida, pos, Quaternion.identity);
            comida.tag = "Comida";
        }
    }

    // ========== MÉTODOS QUE LLAMAN LAS HORMIGAS ==========

    public GameObject FabricarComidaEnGranja(Vector3 posicion)
    {
        return Instantiate(prefabComida, posicion, Quaternion.identity);
    }

    public void DepositarEnAlmacen(GameObject recurso)
    {
        Destroy(recurso);
        almacenComida++;
    }

    public void EntregarAReina(GameObject recurso, bool esComida)
    {
        Destroy(recurso);
        if (esComida) ReinaPideComida = false;
        else ReinaPideAgua = false;
    }

    public void DarCarinioALarvas()
    {
        LarvasNecesitanCarinio = false;
    }

    public GameObject CrearAgua(Vector3 posicion)
    {
        if (prefabAgua == null) return null;

        GameObject agua = Instantiate(prefabAgua, posicion, Quaternion.identity);
        return agua;
    }

    public bool HayComidaEnAlmacen()
    {
        return almacenComida > 0;
    }

    public GameObject SacarComidaDelAlmacen(Vector3 posicionHormiga)
    {
        if (almacenComida <= 0) return null;

        almacenComida--;
        GameObject comida = Instantiate(prefabComida, posicionHormiga + Vector3.up * 0.4f, Quaternion.identity);
        return comida;
    }
}