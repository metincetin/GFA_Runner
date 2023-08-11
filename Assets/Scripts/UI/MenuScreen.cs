using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class MenuScreen : MonoBehaviour
{
	[SerializeField] private Button _playButton;

	[SerializeField] private CanvasGroup _canvasGroup;

	[SerializeField] private Transform _containerTransform;

	private void OnEnable()
	{
		_playButton.onClick.AddListener(OnPlayButtonClicked);
	}

	private void OnDisable()
	{
		_playButton.onClick.RemoveListener(OnPlayButtonClicked);
	}

	public void Open()
	{
		gameObject.SetActive(true);
		_canvasGroup.DOFade(1, 0.2f).From(0);
		_containerTransform.DOScale(1f, 0.2f).From(0.7f);
		_containerTransform.DOLocalMoveY(0, 0.2f).From(-250).SetEase(Ease.OutBack);
	}


	public void Close()
	{
		_canvasGroup.DOFade(0, .2f).OnComplete(() => gameObject.SetActive(false));
	}

	private void OnPlayButtonClicked()
	{
		GameInstance.Instance.StartGame();
	}
}