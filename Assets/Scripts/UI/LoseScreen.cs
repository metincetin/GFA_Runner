using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class LoseScreen : MonoBehaviour
{
	[SerializeField]
	private Button _restartButton;

	[SerializeField]
	private CanvasGroup _canvasGroup;
	
	[SerializeField]
	private Transform _containerTransform;

	private void OnEnable()
	{
		_restartButton.onClick.AddListener(OnRestartButtonClicked);
		_canvasGroup.DOFade(1, .2f).From(0);
		_containerTransform.DOLocalMoveY(0, 0.8f).From(-300).SetEase(Ease.OutBack);
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
