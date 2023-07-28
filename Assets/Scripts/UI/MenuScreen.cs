using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MenuScreen : MonoBehaviour
{
	[SerializeField]
	private Button _playButton;

	private void OnEnable()
	{
		_playButton.onClick.AddListener(OnPlayButtonClicked);
	}

	private void OnDisable()
	{
		_playButton.onClick.RemoveListener(OnPlayButtonClicked);
	}
	
	private void OnPlayButtonClicked()
	{
		GameInstance.Instance.StartGame();
	}
}
