using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Girar Continuamente", story: "[Transform] rconstante rotacion", category: "Action", id: "25e584e728f8a8de5282be4a276fc0e3")]
public partial class GirarContinuamenteAction : Action
{
    [SerializeReference] public BlackboardVariable<Transform> Transform;

    // Velocidad de rotaci�n en grados por segundo.
    [SerializeField]
    private float velocidad = 90f;

    protected override Status OnStart()
    {
        if (Transform.Value == null)
            return Status.Failure;

        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        if (Transform.Value == null)
            return Status.Failure;

        Transform.Value.Rotate(
            Vector3.forward * velocidad * Time.deltaTime,
            Space.Self
        );

        return Status.Running;   // Siempre Running → se puede abortar desde el Conditional Guard
    }


    protected override void OnEnd()
    {

    }
}