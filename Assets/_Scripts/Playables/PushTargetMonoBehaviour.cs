using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Rnd / Poc
// btw, Unity can't serialize interface references
public abstract class PushTargetMonoBehaviour : MonoBehaviour
{
	public abstract void PushFromTimeline(float value);
}
