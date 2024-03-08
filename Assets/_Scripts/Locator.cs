using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Locator
{
	public static CutscenesContainer Cutscenes;
	public static SauceService ShaderSauce;
	public static AppState State = new();
	public static List<InteractionHandle> InteractionHandles { get; private set; } = new();
}
