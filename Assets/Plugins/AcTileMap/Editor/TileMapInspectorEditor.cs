using UnityEngine;
using UnityEditor;
using System;
using System.Linq;
using System.Reflection;

namespace ACANS.TileMap
{
  partial class TileMapEditor : Editor
  {
    SerializedProperty spWidth;
    SerializedProperty spHeight;

    partial void OnInspectorEnable()
    {
      spWidth = serializedObject.FindProperty("width");
      spHeight = serializedObject.FindProperty("height");
    }

    partial void OnInspectorDisable()
    {

    }
    public override void OnInspectorGUI()
    {
      serializedObject.Update();

      EditorGUILayout.Space();
      TileRenderer renderer = tileMap.GetComponent<TileRenderer>();
      if (renderer == null)
      {
        Texture2D tex = EditorGUIUtility.FindTexture("console.erroricon");
        if (GUILayout.Button(new GUIContent("No TileRenderer attached! Click here to add one.", tex), EditorStyles.helpBox))
        {

        }
      }

      EditorGUILayout.Space();
      EditorGUI.BeginChangeCheck();
      tileMap.isInEditMode = GUILayout.Toggle(tileMap.isInEditMode, "", "Button", GUILayout.Height(EditorGUIUtility.singleLineHeight * 1.5f));
      string toggleButtonText = (tileMap.isInEditMode ? "Exit" : "Enter") + " Edit Mode [TAB]";

      if (EditorGUI.EndChangeCheck())
      {
        if (tileMap.isInEditMode)
          OnEnterEditMode();
        else
          OnExitEditMode();
      }


      serializedObject.ApplyModifiedProperties();
    }
  }
}