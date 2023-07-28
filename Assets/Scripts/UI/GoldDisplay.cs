using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GoldDisplay : MonoBehaviour
{
	[SerializeField] private TMP_Text _text;

	private void OnEnable()
	{
		GameInstance.Instance.GoldChanged += OnGoldChanged;
		UpdateUI();
	}

	private void OnDisable()
	{
		GameInstance.Instance.GoldChanged -= OnGoldChanged;
	}

	private void OnGoldChanged(int newGold)
	{
		UpdateUI(newGold);
	}

	private void UpdateUI()
	{
		UpdateUI(GameInstance.Instance.Gold);
	}
	private void UpdateUI(int value)
	{
		_text.text = value.ToString();
	}
}