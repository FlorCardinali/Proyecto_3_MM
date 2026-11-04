using System;
using Unity.Behavior;
using UnityEngine;

[Serializable, Unity.Properties.GeneratePropertyBag]
[Condition(name: "ReinaPideAgua", story: "Reina pide agua", category: "Conditions", id: "7f134bdc9d01df1090f9fc30735b3b11")]
public partial class ReinaPideAguaCondition : Condition
{

    public override bool IsTrue()
    {
        return GameManager.Instancia != null && GameManager.Instancia.ReinaPideAgua;
    }
}
