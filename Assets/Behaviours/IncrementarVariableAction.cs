using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "IncrementarVariable", story: "Incrementar [Variable]", category: "Action", id: "7df160ee47146c85b1fd93a43ded49ca")]
public partial class IncrementarVariableAction : Action
{
    [SerializeReference] public BlackboardVariable<double> Variable;

    protected override Status OnStart()
    {
        if (Variable == null)
            return Status.Failure;

        Variable.Value += 1;

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

