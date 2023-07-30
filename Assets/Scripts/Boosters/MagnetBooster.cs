using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Boosters/Magnet")]
public class MagnetBooster : Booster
{
	[SerializeField, Tooltip("How far should the magnet pull the golds.")]
	private float _radius;
	public override void OnAdded(BoosterContainer container)
	{
		var attractor = container.gameObject.AddComponent<MagnetAttractor>();
		attractor.Radius = _radius;
	}

	public override void OnRemoved(BoosterContainer container)
	{
		Destroy(container.GetComponent<MagnetAttractor>());
	}
}
