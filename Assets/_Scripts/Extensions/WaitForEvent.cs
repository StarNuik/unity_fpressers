// using System;
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public static class ActionExtension
// {
// 	public static IEnumerator WaitFor(this Action action)
// 	{
// 		var wait = true;
// 		Action callback = () => wait = false;

// 		action += callback;
// 		yield return new WaitWhile(() => wait);
// 		action -= callback;
// 	}

// 	public static IEnumerator WaitFor<T>(this Action<T> action)
// 	{
// 		var wait = true;
// 		Action<T> callback = _ => wait = false;

// 		action += callback;
// 		yield return new WaitWhile(() => wait);
// 		action -= callback;
// 	}

// 	// isn't this... incredibly bad & hacky?!
// 	// is it finally time to move to UniTask?
// 	public static IEnumerator WaitFor<T>(this Action<T> action, Action<T> returner)
// 	{
// 		var wait = true;
// 		Action<T> callback = val =>
// 		{
// 			wait = false;
// 			returner(val);
// 		};

// 		action += callback;
// 		Debug.Log("[ ActionExtension.WaitFor<T>(this Action<T>, Action<T>) ] waiting");
// 		yield return new WaitWhile(() => wait);
// 		Debug.Log("[ ActionExtension.WaitFor<T>(this Action<T>, Action<T>) ] continuing");
// 		action -= callback;
// 	}
// }
