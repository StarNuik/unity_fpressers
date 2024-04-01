using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Locator
{
	// non-Room stuff (a separate Locator would be nice)
	public static PersistentState Persistent = new();
	public static PlatformService Platform;

	// state
	public static AppState State = new();
	
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
	public static RecordSpin RecordSpin;
	
	// i wish locator was an instanced class xd
	public static void Clear()
	{
		State = new();

		Cutscenes = null;
		ShaderSauce = null;
		AudioMixer = null; // i wish this was an instanced class
		Bgm = null;
		RouteTracker = null;
		TextDisplay = null;
		Input = null;
		Translation = null;
		RecordSpin = null; // i wish this was an instanced class
	}
	
}
