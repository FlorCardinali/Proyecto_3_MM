using System;
using Unity.Behavior;
using UnityEngine;

[Serializable, Unity.Properties.GeneratePropertyBag]
[Condition(name: "ReinaPideComida", story: "Reina Pide Comida", category: "Conditions", id: "c4722eb84f47c88c2ba43dad1546069d")]
public partial class ReinaPideComidaCondition : Condition
{

    public override bool IsTrue()
    {
        return GameManager.Instancia != null && GameManager.Instancia.ReinaPideComida;
    }
}
