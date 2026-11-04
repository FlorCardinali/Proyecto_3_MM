using System;
using Unity.Behavior;
using UnityEngine;

[Serializable, Unity.Properties.GeneratePropertyBag]
[Condition(name: "HayEnAlmacen", story: "hay comida en almacen", category: "Conditions", id: "57ea835240a73018c523770688598c99")]
public partial class HayEnAlmacenCondition : Condition
{

    public override bool IsTrue()
    {
        return GameManager.Instancia != null && GameManager.Instancia.HayComidaEnAlmacen();
    }
}
