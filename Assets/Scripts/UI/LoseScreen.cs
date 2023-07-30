using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoseScreen : MonoBehaviour
{
	[SerializeField]
	private Button _restartButton;

	private void OnEnable()
	{
		_restartButton.onClick.AddListener(OnRestartButtonClicked);
	}
	
	private void OnDisable()
	{
		_restartButton.onClick.RemoveListener(OnRestartButtonClicked);
	}

	private void OnRestartButtonClicked()
	{
		GameInstance.Instance.RestartLevel();
	}
}
