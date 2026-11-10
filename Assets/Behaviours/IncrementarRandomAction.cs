using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "incrementar random", story: "Incrementar [Variable]", category: "Action", id: "5df0167f7e1d02bfce65aad91e8e2db1")]
public partial class IncrementarRandomAction : Action
{
    [SerializeReference] public BlackboardVariable<double> Variable;

    protected override Status OnStart()
    {
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        return Status.Success;
    }

    protected override void OnEnd()
    {
    }
}

