using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "hacer_caca", story: "[self] hacer [prefab] en su posicion actual", category: "Action", id: "b0c3a6312e3d14597f301bdfeeea0e3e")]
public partial class HacerCacaAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Self;
    [SerializeReference] public BlackboardVariable<GameObject> Prefab;
    protected override Status OnStart()
    {
        if (Prefab.Value == null)
            return Status.Failure;
        if (Self.Value == null)
            return Status.Failure;

        UnityEngine.Object.Instantiate(Prefab.Value,
            Self.Value.transform.position,
            Quaternion.identity);
        return Status.Success;
    }

}

