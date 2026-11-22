using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Reset Transform", story: "Resetear [Transform] a valores de base", category: "Action", id: "9f01bb58aaeb7e52f24384bebe4a8e30")]
public partial class ResetTransformAction : Action
{
    [SerializeReference] public BlackboardVariable<Transform> Transform;

    [SerializeField] private bool resetRotation = true;
    [SerializeField] private bool resetScale = false;
    [SerializeField] private bool resetPosition = false;

    // Valores a los que queremos volver
    [SerializeField] private Vector3 rotationEuler = new Vector3(90f,0f,0f);  
    [SerializeField] private Vector3 scale = Vector3.one;
    [SerializeField] private Vector3 position = new Vector3(0f, 0.25f, 0.303f);

    protected override Status OnStart()
    {
        if (Transform.Value == null)
            return Status.Failure;

        if (resetRotation)
            Transform.Value.rotation = Quaternion.Euler(rotationEuler);

        if (resetScale)
            Transform.Value.localScale = scale;

        if (resetPosition)
            Transform.Value.position = position;

        return Status.Success;
    }

    protected override Status OnUpdate()
    {
        return Status.Success;
    }
}
