using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "ComerComida", story: "Consumir [Prefab]", category: "Action", id: "488a897918d1a53a7e61a8e607bf274d")]
public partial class ComerComidaAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Prefab;
    protected override Status OnStart()
    {
        if (Prefab.Value == null)
        {
            LogFailure("No hay prefab para destruir.");
            return Status.Failure;
        }
        GameObject.Destroy(Prefab.Value);
        return Status.Success;
    }

    protected override Status OnUpdate()
    {
        return Status.Success;
    }

    protected override void OnEnd()
    {
    }
}

