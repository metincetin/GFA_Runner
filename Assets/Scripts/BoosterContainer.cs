using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosterContainer : MonoBehaviour
{
	private List<BoosterInstance> _activeBoosters = new List<BoosterInstance>();
	
	public event Action<BoosterInstance> BoosterAdded;
	public event Action<Booster> BoosterRemoved;
	
	public void AddBooster(Booster booster)
	{
		foreach (var instance in _activeBoosters)
		{
			if (instance.Booster == booster)
			{
				instance.ResetDuration();
				return;
			}
		}

		var boosterInstance = new BoosterInstance(booster);
		_activeBoosters.Add(boosterInstance);
		booster.OnAdded(this);
		BoosterAdded?.Invoke(boosterInstance);
	}

	public void RemoveBooster(Booster booster)
	{
		foreach (var instance in _activeBoosters)
		{
			if (instance.Booster == booster)
			{
				instance.RemainingDuration = 0;
			}
		}
	}

	private void Update()
	{
		for (int i = _activeBoosters.Count - 1; i >= 0; i--)
		{
			var instance = _activeBoosters[i];
			instance.RemainingDuration -= Time.deltaTime;
			if (instance.RemainingDuration <= 0)
			{
				instance.Booster.OnRemoved(this);
				_activeBoosters.RemoveAt(i);
				BoosterRemoved?.Invoke(instance.Booster);
			}
		}
	}

	public class BoosterInstance
	{
		public Booster Booster { get; set; }
		public float RemainingDuration { get; set; }

		public BoosterInstance(Booster booster)
		{
			Booster = booster;
			ResetDuration();
		}

		public void ResetDuration()
		{
			RemainingDuration = Booster.Duration;
		}
	}
}
