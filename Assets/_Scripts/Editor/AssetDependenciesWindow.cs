using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UIElements;


public class AssetDependenciesWindow : EditorWindow
{
	private ListView oldListview;
	private List<string> items = new();

	[MenuItem("Window/Asset Dependencies")]
	public static void ShowSelf()
	{
		var window = GetWindow<AssetDependenciesWindow>();
		window.titleContent = new("Asset Dependencies");
	}

	public void CreateGUI()
	{
		var root = rootVisualElement;

		var button = new Button();
		button.text = "(Re)Generate";
		button.clicked += Regenerate;
		root.Add(button);

		var clear = new Button();
		clear.text = "Clear";
		clear.clicked += Clear;
		root.Add(clear);

		oldListview = Listview(new());
		root.Add(oldListview);
	}

	private void Clear()
	{
		items = new();
		oldListview.itemsSource = new List<string>();
		oldListview.Rebuild();
	}

	private void Regenerate()
	{
		var scene = EditorSceneManager.GetSceneManagerSetup()[0].path;

		var deps = AssetDatabase
			.GetDependencies(scene, recursive: true)
			.Where(path => path.StartsWith("Assets/Gitignore"))
			.ToList();

		items = deps;


		var listview = Listview(items);
		rootVisualElement.Remove(oldListview);
		rootVisualElement.Add(listview);
		oldListview = listview;
	}

	private ListView Listview(List<string> strings)
	{
		var listview = new ListView();
		listview.itemsSource = strings;
		listview.makeItem = () => new Label();
		listview.bindItem = (elem, index) => (elem as Label).text = strings[index];
		listview.showAlternatingRowBackgrounds = AlternatingRowBackground.ContentOnly;
		return listview;
	}
}
