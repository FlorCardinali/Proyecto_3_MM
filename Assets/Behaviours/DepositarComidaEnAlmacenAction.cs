using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "DepositarComidaEnAlmacen", story: "[Self] deposita [ComidaActual] en el almacen", category: "Action/Hormiga", id: "e0f465e3c96a3db4d6deb68013e55411")]
public partial class DepositarComidaEnAlmacenAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Self;
    [SerializeReference] public BlackboardVariable<GameObject> ComidaActual;
    [SerializeReference] public BlackboardVariable<Transform> zonaDeAlmacen;
    protected override Status OnStart()
    {
        if (GameManager.Instancia == null)
            return Status.Failure;
        GameManager.Instancia.DepositarEnAlmacen(ComidaActual.Value);
        ComidaActual.Value = null;

        return Status.Success;
    }

    protected override Status OnUpdate()
    {
        return Status.Success;
    }

}

