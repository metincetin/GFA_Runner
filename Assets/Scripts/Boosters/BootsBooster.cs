using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Boosters/Boots")]
public class BootsBooster : Booster
{
    [SerializeField]
    private float _multiplier = 2.5f;
    
    public override void OnAdded(BoosterContainer container)
    {
        if (container.TryGetComponent(out PlayerMovement playerMovement))
        {
            playerMovement.JumpPower *= _multiplier;
        }
    }

    public override void OnRemoved(BoosterContainer container)
    {
        if (container.TryGetComponent(out PlayerMovement playerMovement))
        {
            playerMovement.JumpPower /= _multiplier;
        }
    }
}
