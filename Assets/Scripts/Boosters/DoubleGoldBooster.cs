using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Boosters/2x Gold")]
public class DoubleGoldBooster : Booster
{
	public override void OnAdded(BoosterContainer container)
	{
		GameInstance.Instance.GoldMultiplier = 2;
	}

	public override void OnRemoved(BoosterContainer container)
	{
		GameInstance.Instance.GoldMultiplier = 1;
	}
}
