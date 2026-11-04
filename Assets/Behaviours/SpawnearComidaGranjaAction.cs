using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "SpawnearComidaGranja", story: "[Self] fabrica comida y la guarda en [ComidaActual]", category: "Action/Hormiga", id: "3511d266715f9466724ea12c210f9f59")]
public partial class SpawnearComidaGranjaAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Self;
    [SerializeReference] public BlackboardVariable<GameObject> ComidaActual;
    [SerializeReference] public BlackboardVariable<Transform> zonaDeGranja;
    protected override Status OnStart()
    {
        if (Self.Value == null || GameManager.Instancia == null || zonaDeGranja.Value == null)
            return Status.Failure;

        Vector3 pos = zonaDeGranja.Value.position + Vector3.up * 0.3f;
        GameObject comida = GameManager.Instancia.FabricarComidaEnGranja(pos);

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

