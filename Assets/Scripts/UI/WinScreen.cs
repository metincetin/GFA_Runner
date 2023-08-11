using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class WinScreen : MonoBehaviour
{
	[SerializeField]
	private Button _nextLevelButton;

	[SerializeField]
	private RectTransform _titleContainer;

	[SerializeField]
	private CanvasGroup _canvasGroup;

	private void OnEnable()
	{
		_nextLevelButton.onClick.AddListener(OnNextLevelButtonPressed);
		var defaultSizeDelta = _titleContainer.sizeDelta;
		_titleContainer.DOSizeDelta(defaultSizeDelta, 0.5f).From(new Vector2(200, defaultSizeDelta.y));
		_titleContainer.DOLocalMoveY(_titleContainer.transform.localPosition.y, 0.4f).From(_titleContainer.transform.localPosition.y - 100);
		_canvasGroup.DOFade(1, 0.2f).From(0);
	}
	
	private void OnDisable()
	{
		_titleContainer.DOComplete();
		_nextLevelButton.onClick.RemoveListener(OnNextLevelButtonPressed);
	}

	private void OnNextLevelButtonPressed()
	{
		GameInstance.Instance.LoadCurrentLevel();
	}
}
