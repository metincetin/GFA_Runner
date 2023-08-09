using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Gold : Collectible
{
	[SerializeField]
	private Transform _graphics;
	
	[SerializeField]
	private ParticleSystem _collectParticle;
	
	protected override void OnCollected(GameObject collectedBy)
	{
		GameInstance.Instance.Gold += Mathf.RoundToInt(1 * GameInstance.Instance.GoldMultiplier);
		
		_graphics.DOKill();
		_graphics.SetParent(null);
		_graphics.DOMoveY(_graphics.position.y + 5, 0.2f).OnComplete(() => Destroy(_graphics.gameObject));
		_graphics.DOScale(0.5f, 0.2f);
		Instantiate(_collectParticle, transform.position, Quaternion.identity);


	}
}