using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditorInternal;
using System.IO;
using System.Text;

[CustomEditor(typeof(WindowsManager))]
public class WindowManagerEditor : Editor {

	private ReorderableList list;

	public override void OnInspectorGUI ()
	{
		DrawDefaultInspector ();

		list.DoLayoutList ();

		serializedObject.ApplyModifiedProperties ();

		if (GUILayout.Button ("Generate window enum")) {
			var windows = ((WindowsManager)target).windows;
			var total = windows.Length;

			var sb = new StringBuilder ();
			sb.Append ("public enum Windows{");
			sb.Append ("None,");

			for (int i = 0; i < total; i++) {
				sb.Append(windows[i].name.Replace(" ", ""));
				if (i < total - 1) {
					sb.Append (",");
				}
			}
			sb.Append("}");
			var path = EditorUtility.SaveFilePanel("Save the window enum", "", "WindowsEnum.cs", "cs");

			using(FileStream fs = new FileStream(path, FileMode.Create)){
				using(StreamWriter writer = new StreamWriter(fs)){
					writer.Write(sb.ToString());
				}
			}
			AssetDatabase.Refresh();
		}
	}

	private void OnEnable(){
		list = new ReorderableList (serializedObject, serializedObject.FindProperty ("windows"), true, true, true, true);


		list.drawHeaderCallback = (Rect Rect) => {
			EditorGUI.LabelField(Rect, "window");
		};

		list.drawElementCallback = (Rect rect, int index, bool isActive, bool isFocused) => {
			
			var element = list.serializedProperty.GetArrayElementAtIndex(index);
			EditorGUI.PropertyField (new Rect(rect.x, rect.y, Screen.width - 75, EditorGUIUtility.singleLineHeight), element, GUIContent.none);
		};
	}

}
