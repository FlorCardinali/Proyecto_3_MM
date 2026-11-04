using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "OrdenarCaminarA", story: "[Self] ordena caminar", category: "Action/Hormiga", id: "0414fd799833a0f3a04db5e9cf6970ff")]
public partial class OrdenarCaminarAAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Self;

    protected override Status OnStart()
    {
        if (Self.Value == null) return Status.Failure;

        var anim = Self.Value.GetComponentInChildren<ControladorAnimacionHormiga>();
        if (anim != null)
        {
            anim.OrdenarCaminar();
        }

        return Status.Success;
    }

    protected override Status OnUpdate()
    {
        return Status.Success;
    }
}