using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Editor = UnityEngine.SerializeField;

public class TranslateService : MonoBehaviour
{
	[Editor] Button button;
	[Editor] TMP_Text textfield;
	[Editor] TextAsset text;

	private TranslationService translation => Locator.Translation;

	private void Awake()
	{
		button.onClick.AddListener(NextLanguage);
	}

	private void Start()
	{
		textfield.text = translation.ToString(text);
	}

	private void NextLanguage()
	{
		translation.NextLanguage();
		textfield.text = translation.ToString(text);
	}
}
