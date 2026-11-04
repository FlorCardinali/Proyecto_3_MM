using UnityEngine;
using UnityEngine.AI;

public class ControladorAnimacionHormiga : MonoBehaviour
{
    public enum EstadoHormiga { Idle, Walk, LayDown }

    [Header("Referencias")]
    [SerializeField] private NavMeshAgent agentePadre;

    [Header("Estados de Animación")]
    public EstadoHormiga estadoActual = EstadoHormiga.Idle;

    [Header("Fotogramas")]
    [SerializeField] private Texture2D[] fotogramasIdle;
    [SerializeField] private float fpsIdle = 6f;
    [Space]
    [SerializeField] private Texture2D[] fotogramasWalk;
    [SerializeField] private float fpsWalk = 12f;
    [Space]
    [SerializeField] private Texture2D[] fotogramasLayDown;
    [SerializeField] private float fpsLayDown = 4f;

    private Material miMaterial;
    private int frameActual;
    private float temporizador;
    private EstadoHormiga ultimoEstado;
    private Vector3 escalaOriginal;

    private static readonly int BaseMapID = Shader.PropertyToID("_BaseMap");

    void Start()
    {
        Renderer rend = GetComponent<Renderer>();
        if (rend != null)
            miMaterial = rend.material;

        if (agentePadre == null)
            agentePadre = GetComponentInParent<NavMeshAgent>();

        if (agentePadre != null)
        {
            agentePadre.updateRotation = false;
            agentePadre.updateUpAxis = false;
        }

        escalaOriginal = transform.localScale;
        ultimoEstado = estadoActual;
    }

    void Update()
    {
        // Voltear sprite según dirección de movimiento
        if (agentePadre != null)
        {
            if (agentePadre.velocity.x > 0.1f)
                transform.localScale = new Vector3(-escalaOriginal.x, escalaOriginal.y, escalaOriginal.z);
            else if (agentePadre.velocity.x < -0.1f)
                transform.localScale = escalaOriginal;
        }

        // Reiniciar animación si cambió el estado
        if (estadoActual != ultimoEstado)
        {
            ultimoEstado = estadoActual;
            frameActual = 0;
            temporizador = 0f;
        }

        // Reproducir la animación correspondiente
        switch (estadoActual)
        {
            case EstadoHormiga.Idle:
                Animar(fotogramasIdle, fpsIdle);
                break;
            case EstadoHormiga.Walk:
                Animar(fotogramasWalk, fpsWalk);
                break;
            case EstadoHormiga.LayDown:
                Animar(fotogramasLayDown, fpsLayDown);
                break;
        }
    }

    private void Animar(Texture2D[] clips, float fps)
    {
        if (clips == null || clips.Length == 0 || miMaterial == null) return;

        temporizador += Time.deltaTime;
        if (temporizador >= 1f / fps)
        {
            temporizador = 0f;
            frameActual = (frameActual + 1) % clips.Length;
            miMaterial.SetTexture(BaseMapID, clips[frameActual]);
        }
    }

    // ========== Métodos públicos para el Behavior Graph ==========
    // Solo cambian el estado visual. El movimiento lo maneja Navigate To Target.

    public void OrdenarCaminar()
    {
        estadoActual = EstadoHormiga.Walk;
    }

    public void OrdenarQuedarseQuieta()
    {
        estadoActual = EstadoHormiga.Idle;
    }

    public void OrdenarAcostarse()
    {
        estadoActual = EstadoHormiga.LayDown;
    }
}