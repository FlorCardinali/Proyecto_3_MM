using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "ReiniciarValorDeVariable", story: "Reiniciar [Variable]", category: "Action", id: "a74152c01dc231962984591d230e8b61")]
public partial class ReiniciarValorDeVariableAction : Action
{
    [SerializeReference] public BlackboardVariable<double> Variable;

    protected override Status OnStart()
    {
        if (Variable == null)
            return Status.Failure;

        Variable.Value = 0;

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

