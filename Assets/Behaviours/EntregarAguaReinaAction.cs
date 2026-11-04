using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Entregar Agua Reina", story: "[Self] entrega [AguaActual] a la Reina", category: "Action", id: "27f72dab98d299214f806c46e3bde2f5")]
public partial class EntregarAguaReinaAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Self;
    [SerializeReference] public BlackboardVariable<GameObject> AguaActual;

    protected override Status OnStart()
    {
        if (AguaActual.Value == null) return Status.Failure;

        GameManager.Instancia.EntregarAReina(AguaActual.Value, esComida: false);
        AguaActual.Value = null;

        return Status.Success;
    }

    protected override Status OnUpdate()
    {
        return Status.Success;
    }
}

