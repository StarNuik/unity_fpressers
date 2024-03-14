using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Locator
{
	// state
	public static AppState State = new();
	
	// containers
	public static CutscenesContainer Cutscenes;

	// services
	public static ShaderSauceService ShaderSauce;
	public static BgmStartService Bgm;
	public static EndingRouteService RouteTracker;
	
	// sequences
	public static SplashSequence Splash;
	
}
