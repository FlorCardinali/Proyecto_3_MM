using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "SpawenarAgua", story: "[Self] extrae agua de [zonaDeAgua] y la guarda en [AguaActual]", category: "Action/Hormiga", id: "3d1ba2b95451e49e9f5642b5f34f40e0")]
public partial class SpawenarAguaAction : Action
{

    [SerializeReference] public BlackboardVariable<GameObject> Self;
    [SerializeReference] public BlackboardVariable<GameObject> AguaActual;
    [SerializeReference] public BlackboardVariable<Transform> zonaDeAgua; 

    protected override Status OnStart()
    {
        if (Self.Value == null || GameManager.Instancia == null || zonaDeAgua.Value == null)
            return Status.Failure;

        Vector3 pos = zonaDeAgua.Value.position + Vector3.up * 0.3f;
        GameObject agua = GameManager.Instancia.CrearAgua(pos);

        if (agua == null) return Status.Failure;

        AguaActual.Value = agua;
        agua.transform.SetParent(Self.Value.transform);
        agua.transform.localPosition = new Vector3(0f, 0.5f, 0f);

        return Status.Success;
    }

    protected override Status OnUpdate()
    {
        return Status.Success;
    }
}

