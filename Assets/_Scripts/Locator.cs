using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Locator
{
	// state
	public static AppState State = new();
	public static PersistentState Persistent = new();
	
	// containers
	public static CutscenesContainer Cutscenes;

	// services
	public static ShaderSauceService ShaderSauce;
	public static AudioMixerService AudioMixer;
	public static BgmStartService Bgm;
	public static EndingRouteService RouteTracker;
	public static TextDisplayService TextDisplay;
	public static InputService Input;
	public static TranslationService Translation;
	
	// sequences
	public static SplashSequence Splash;

	// i wish locator was an instanced class xd
	public static void Clear()
	{
		State = new();
		Persistent = new();

		Cutscenes = null;
		ShaderSauce = null;
		AudioMixer = null; // i wish this was an instanced class
		Bgm = null;
		RouteTracker = null;
		TextDisplay = null;
		Input = null;
		Splash = null;
		Translation = null;
	}
	
}
