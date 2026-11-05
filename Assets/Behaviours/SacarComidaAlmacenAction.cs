using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "SacarComidaAlmacen", story: "[Self] saca comida del [zonaDeAlmacen] y la guarda en [ComidaActual]", category: "Action", id: "03f75ca943ddfec63eefea8bf297df0f")]
public partial class SacarComidaAlmacenAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Self;
    [SerializeReference] public BlackboardVariable<GameObject> ComidaActual;
    [SerializeReference] public BlackboardVariable<Transform> zonaDeAlmacen;
    protected override Status OnStart()
    {
        if (Self.Value == null || GameManager.Instancia == null || zonaDeAlmacen.Value == null)
            return Status.Failure;
        Vector3 pos = zonaDeAlmacen.Value.position + Vector3.up * 0.3f;
        GameObject comida = GameManager.Instancia.SacarComidaDelAlmacen(pos);

        if (comida == null) return Status.Failure;

        ComidaActual.Value = comida;
        comida.transform.SetParent(Self.Value.transform);
        comida.transform.localPosition = new Vector3(0f, 0.5f, 0f);
        return Status.Success;
    }

    protected override Status OnUpdate()
    {
        return Status.Success;
    }
   
}

