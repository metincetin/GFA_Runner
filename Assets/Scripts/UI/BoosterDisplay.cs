using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoosterDisplay : MonoBehaviour
{
	public BoosterContainer.BoosterInstance BoosterInstance { get; set; }

	[SerializeField]
	private Image _boosterIcon;

	[SerializeField]
	private Image _fillBar;

	private void Start()
	{
		_boosterIcon.sprite = BoosterInstance.Booster.Icon;
	}


	private void Update()
	{
		_fillBar.fillAmount = BoosterInstance.RemainingDuration / BoosterInstance.Booster.Duration;
	}

}
