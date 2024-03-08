using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Editor = UnityEngine.SerializeField;

public class SauceService : MonoBehaviour
{
	[Editor] SauceController shaderSauce;
	[Editor] AnimationCurve sauceCurve;

	private bool isEnabled;
	private int totalInteractions;
	
	private AppState state => Locator.State;
	private bool isSuppressed => !isEnabled || state.ShaderSauceIsTimelined;
	private int interactionsLeft => Locator.InteractionHandles.Count;

	public void Enable(int totalInteractions)
	{
		this.totalInteractions = totalInteractions;
		isEnabled = true;
	}

	private void Awake()
	{
		Locator.ShaderSauce = this;
	}

	private void Update()
	{
		if (isSuppressed)
			return;
		
		float max = totalInteractions;
		float current = interactionsLeft;
		var f = 1f - current / max;
		shaderSauce.Strength = sauceCurve.Evaluate(f);
		shaderSauce.FogMilkRatio = 0f;
		shaderSauce.Apply();
	}
}
