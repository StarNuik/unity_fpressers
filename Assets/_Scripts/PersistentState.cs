using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lang = TranslationService.Language;

public class PersistentState
{
	public Lang Language
	{
		get => (Lang)PlayerPrefs.GetInt("__Language", 0);
		set => PlayerPrefs.SetInt("__Language", (int)value);
	}
}
