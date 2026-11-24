using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "EntregarComidaReina", story: "[Self] entrega [ComidaActual] a la Reina", category: "Action/Hormiga", id: "c219c6caa4f2bffa20b056bf6b27eed4")]
public partial class EntregarComidaReinaAction : Action
{

    [SerializeReference] public BlackboardVariable<GameObject> Self;
    [SerializeReference] public BlackboardVariable<GameObject> ComidaActual;

    protected override Status OnStart()
    {
        if (ComidaActual.Value == null) return Status.Failure;
        if (GameManager.Instancia == null) return Status.Failure;

        GameManager.Instancia.EntregarAReina(ComidaActual.Value, esComida: true);
        ComidaActual.Value = null;

        return Status.Success;
    }

    protected override Status OnUpdate()
    {
        return Status.Success;
    }

  
}

