using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Editor = UnityEngine.SerializeField;
using Request = PcScreenMaterialController.Props;

[ExecuteInEditMode]
public class PcScreenMaterialService : MonoBehaviour
{
	[Editor] PcScreenMaterialController driver;

	private Request? timelineReq;

	public void PushTexture(Texture2D texture)
	{
		var req = timelineReq.GetValueOrDefault();
		req.EmissionMap = texture;
		timelineReq = req;
	}

	public void PushStrength(float strength)
	{
		var req = timelineReq.GetValueOrDefault();
		req.EmissionStrength = strength;
		timelineReq = req;
	}

	private void LateUpdate()
	{
		var vals = ChooseRequest();

		driver.Properties = vals;
		driver.Apply();

		ClearRequests();
	}

	private Request ChooseRequest()
	{
		return timelineReq.GetValueOrDefault();
	}

	private void ClearRequests()
	{
		timelineReq = null;
	}
}
