using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Locator
{
	// state
	public static AppState State = new();
	
	// containers
	public static CutscenesContainer Cutscenes;
	public static List<InteractionHandle> InteractionHandles { get; private set; } = new();

	// services
	public static ShaderSauceService ShaderSauce;
	public static BgmService Bgm;
	
	// sequences
	public static SplashSequence Splash;
	
}
