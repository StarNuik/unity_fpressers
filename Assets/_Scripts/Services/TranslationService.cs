using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslationService : MonoBehaviour
{
	public enum Language
	{
		English,
		Russian,
	}

	private PersistentState persistent => Locator.Persistent;
	private AppState state => Locator.State;

	private Language current
	{
		get => persistent.Language;
		set => persistent.Language = value;
	}

	public string ToString(TextAsset asset)
	{
		return asset.ToString(current);
	}

	// no need for fancy selection logic (for now)
	public void NextLanguage()
	{
		var next = current switch
		{
			Language.English => Language.Russian,
			Language.Russian => Language.English,
			_ => throw new NotImplementedException(),
		};

		current = next;

		// state.InvokeLanguageChanged();
	}

	private void Awake()
	{
		Locator.Translation = this;
	}
}
