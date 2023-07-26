using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : Collectible
{
	protected override void OnCollected()
	{
		GameInstance.Instance.Gold++;
		Debug.Log(GameInstance.Instance.Gold);
	}
}