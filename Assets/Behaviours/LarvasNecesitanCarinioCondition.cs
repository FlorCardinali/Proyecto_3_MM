using System;
using Unity.Behavior;
using UnityEngine;

[Serializable, Unity.Properties.GeneratePropertyBag]
[Condition(name: "LarvasNecesitanCarinio", story: "Larvas Necesitan Carinio", category: "Conditions", id: "50f1c9f759fffb3aabad387895007b5f")]
public partial class LarvasNecesitanCarinioCondition : Condition
{

    public override bool IsTrue()
    {
        return GameManager.Instancia != null && GameManager.Instancia.LarvasNecesitanCarinio;
    }
}
