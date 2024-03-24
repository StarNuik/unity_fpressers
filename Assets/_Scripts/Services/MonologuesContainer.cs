using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Editor = UnityEngine.SerializeField;
using Route = EndingRouteService.RouteType;

public class MonologuesContainer : MonoBehaviour
{
	[Editor] List<RouteListPair> RouteTexts = new();

	private Dictionary<Route, Dictionary<Cutscene, TextAsset>> store;

	public TextAsset GetMonologue(Cutscene cutscene, Route route)
	{
		return store[route][cutscene];
	}

	private void Awake()
	{
		store = RouteTexts.ToDictionary(
			p => p.Route,
			p => p.CutsceneTexts.ToDictionary(
				q => q.Cutscene,
				q => q.TextAsset
			)
		);
	}

	[System.Serializable]
	private struct RouteListPair
	{
		public Route Route;
		public List<CutsceneTextPair> CutsceneTexts;
	}

	[System.Serializable]
	private struct CutsceneTextPair
	{
		public Cutscene Cutscene;
		public TextAsset TextAsset;
	}
}
