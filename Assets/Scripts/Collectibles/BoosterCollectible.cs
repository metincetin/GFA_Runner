using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosterCollectible : Collectible
{
    [SerializeField]
    private Booster _booster;

    protected override void OnCollected(GameObject collectedBy)
    {
        if (collectedBy.TryGetComponent<BoosterContainer>(out BoosterContainer container))
        {
            container.AddBooster(_booster);
        }
    }
}
