using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using Editor = UnityEngine.SerializeField;

public class MilkFxController : MonoBehaviour
{
	[Editor] RenderObjects milkFx;

	private ReplacedMaterial material;
	
	public static void ApplyTo(Material target, float strength, float ratio)
	{
		if (target == null)
			return;

		target.SetFloat("_Strength", strength);
		target.SetFloat("_FogMilkRatio", ratio);
	}

	private void OnEnable()
	{
		material = new(() => milkFx.settings.overrideMaterial, val => milkFx.settings.overrideMaterial = val);
	}

	private void OnDisable()
	{
		material.Return();
	}

	private void LateUpdate()
	{
		var state = Locator.State;
		ApplyTo(material, state.MilkStrength, state.FogMilkRatio);
	}

	
}
