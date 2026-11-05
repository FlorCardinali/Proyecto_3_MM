using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Recoger", story: "[Self] recoge [CualquierCosa]", category: "Action", id: "0ba475fc11b81e00837918db6ecf37db")]
public partial class RecogerCacaAction : Action
{

    [SerializeReference] public BlackboardVariable<GameObject> Self;
    [SerializeReference] public BlackboardVariable<GameObject> CualquierCosa;

    protected override Status OnStart()
    {
        if (Self.Value == null || CualquierCosa.Value == null)
        {
            Debug.Log("RecogerCacaAction: Self o CualquierCosa es null");
            return Status.Failure;
        }

        // Hacer que la caca sea hija de la hormiga (se mueve con ella)
        CualquierCosa.Value.transform.SetParent(Self.Value.transform);

        // Opcional: subirla un poquito para que se vea que la está cargando
        CualquierCosa.Value.transform.localPosition = new Vector3(0f, 0.4f, 0f);

        // Opcional: desactivar el collider de la caca para que no moleste
        var col = CualquierCosa.Value.GetComponent<Collider>();
        if (col != null) col.enabled = false;

        return Status.Success;
    }

    protected override Status OnUpdate()
    {
        return Status.Success;
    }
}

