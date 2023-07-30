using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinScreen : MonoBehaviour
{
	[SerializeField]
	private Button _nextLevelButton;

	private void OnEnable()
	{
		_nextLevelButton.onClick.AddListener(OnNextLevelButtonPressed);
	}
	
	private void OnDisable()
	{
		_nextLevelButton.onClick.RemoveListener(OnNextLevelButtonPressed);
	}

	private void OnNextLevelButtonPressed()
	{
		GameInstance.Instance.LoadCurrentLevel();
	}
}
