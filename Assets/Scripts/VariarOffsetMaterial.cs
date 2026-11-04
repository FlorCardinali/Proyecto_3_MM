using UnityEngine;

public class VariarOffsetMaterial : MonoBehaviour
{
    private Renderer myRenderer;
    private MaterialPropertyBlock propBlock;

    void Awake()
    {
        myRenderer = GetComponent<Renderer>();
        propBlock = new MaterialPropertyBlock();
    }

    void Start()
    {
        myRenderer.GetPropertyBlock(propBlock);
        float randomOffsetX = Random.Range(0f, 1f);
        float randomOffsetY = Random.Range(0f, 1f);

        
        propBlock.SetVector("_BaseMap_ST", new Vector4(0.3f, 0.3f, randomOffsetX, randomOffsetY));

        myRenderer.SetPropertyBlock(propBlock);
    }
}