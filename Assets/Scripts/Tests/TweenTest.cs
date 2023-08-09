using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class TweenTest : MonoBehaviour
{
	[SerializeField]
	private string _textValue;
	
	private int _displayedText;

	
	[SerializeField]
	private TMP_Text _text;
    
	private void Start()
	{
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			DOTween.To(() => _displayedText, SetDisplayedText, _textValue.Length, 1);
		}
	}

	private void SetDisplayedText(int value)
	{
		_displayedText = value;
		_text.text = _textValue.Substring(0, _displayedText);
	}
}
