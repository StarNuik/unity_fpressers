using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Editor = UnityEngine.SerializeField;

public class SauceService : MonoBehaviour
{
	[Editor] SauceController shaderSauce;
	[Editor] AnimationCurve sauceCurve;
	[Min(0.01f)]
	[Editor] float fSpeed;

	private int total;
	private float targetF;
	private float currentF;

	private bool isBlocked => Locator.State.IsPlayingCutscene;

	public void Enable(int total)
	{
		this.total = total;
		currentF = 0f;
		targetF = 0f;
	}

	public void UpdateTarget(int left)
	{
		targetF = 1f - (float)left / (float)total;
	}

	private void Awake()
	{
		Locator.ShaderSauce = this;
	}

	private void Update()
	{
		if (isBlocked)
			return;
	
		currentF = Mathf.MoveTowards(currentF, targetF, fSpeed * Time.deltaTime);

		shaderSauce.Strength = sauceCurve.Evaluate(currentF);
		shaderSauce.FogMilkRatio = 0f;
		shaderSauce.Apply();
	}
}
