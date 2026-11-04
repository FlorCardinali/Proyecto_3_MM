using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "DarCarinioALarvas", story: "[Self] le da carinio a las larvas", category: "Action", id: "53e8d2fc5e559631f2e87bdf918f89a7")]
public partial class DarCarinioALarvasAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Self;
    protected override Status OnStart()
    {
        if (GameManager.Instancia == null)
            return Status.Failure;
        GameManager.Instancia.DarCarinioALarvas();
        return Status.Success;
    }

    protected override Status OnUpdate()
    {
        return Status.Success;
    }

  
}

