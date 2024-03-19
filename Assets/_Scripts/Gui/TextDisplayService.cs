using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using Editor = UnityEngine.SerializeField;

public class TextDisplayService : MonoBehaviour
{
	[Editor] TMP_Text text;
	[Min(0.01f)]
	[Editor] float fadeDuration = 0.5f;

	public string MonologueChannel { get; set; }
	public string SplashChannel { get; set; }
	public string InteractionHintChannel { get; set; }
	public string MovementHintChannel { get; set; }
	const string NullChannel = "null";

	private float alphaF = 0f;

	private float fadeSpeed => 1f / fadeDuration;

	private string target
	{
		get => text.text;
		set => text.text = value;
	}

	// not great, but I'll survive if this is a once in a lifetime sin
	public float FadeDuration => fadeDuration;

	private void Awake()
	{
		alphaF = 0f;

		Locator.TextDisplay = this;
	}

	private void Update()
	{
		var next = ChooseChannel();
		
		// a functional-like approach to an fsm
		// i don't like it too much, but this is far simpler than my CoroutineFsm
		// be wary: this approach can have nasty side effects
		var isFadingIn = ReferenceEquals(target, next) && !ReferenceEquals(target, NullChannel);
		var isFadingOut = !ReferenceEquals(target, next);
		if (alphaF == 0f)
		{
			target = next;
		}

		if (isFadingIn)
		{
			alphaF = Mathf.MoveTowards(alphaF, 1f, fadeSpeed * Time.deltaTime);
		}

		if (isFadingOut)
		{
			alphaF = Mathf.MoveTowards(alphaF, 0f, fadeSpeed * Time.deltaTime);
		}

		text.SetAlpha(DOVirtual.EasedValue(0f, 1f, alphaF, Ease.InQuad));
	}

	private string ChooseChannel()
	{
		if (MonologueChannel != null) return MonologueChannel;
		if (SplashChannel != null) return SplashChannel;
		if (InteractionHintChannel != null) return InteractionHintChannel;
		if (MovementHintChannel != null) return MovementHintChannel;
		return NullChannel;
	}
}
