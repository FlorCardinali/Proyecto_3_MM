using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Depocitar", story: "[Self] deposita caca [CacaActual]", category: "Action", id: "78030e66112e5083e9c9256d9a954a9f")]
public partial class DepocitarAction : Action
{

    [SerializeReference] public BlackboardVariable<GameObject> Self;
    [SerializeReference] public BlackboardVariable<GameObject> CacaActual;

    protected override Status OnStart()
    {
        if (CacaActual.Value == null)
            return Status.Failure;

        // Destruir la caca
        UnityEngine.Object.Destroy(CacaActual.Value);
        CacaActual.Value = null;

        // Volver a Idle
        var anim = Self.Value?.GetComponentInChildren<ControladorAnimacionHormiga>();
        if (anim != null)
            anim.OrdenarQuedarseQuieta();

        return Status.Success;
    }

    protected override Status OnUpdate()
    {
        return Status.Success;
    }
}

