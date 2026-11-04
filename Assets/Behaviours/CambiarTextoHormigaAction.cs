using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "CambiarTextoHormiga", story: "[Self] dice [Texto]", category: "Action/Hormiga", id: "0fe4427393e9c7596135a886d6113e98")]
public partial class CambiarTextoHormigaAction : Action
{

    [SerializeReference] public BlackboardVariable<GameObject> Self;
    [SerializeReference] public BlackboardVariable<string> Texto;

    protected override Status OnStart()
    {
        var controlador = Self.Value.GetComponentInChildren<ControladorTextoHormiga>();
        if (controlador != null)
        {
            controlador.CambiarTexto(Texto.Value);
        }

        return Status.Success;
    }

    protected override Status OnUpdate()
    {
        return Status.Success;
    }
}

