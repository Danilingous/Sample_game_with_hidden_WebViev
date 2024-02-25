#if UNITY_EDITOR
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(MainSettings))]
[CanEditMultipleObjects]
public class MainSettingsEditor : Editor
{
    private SerializedProperty complete;
    private SerializedProperty processing;
    private SerializedProperty safeMode;
    private int num;
    
    private void OnEnable()
    {
        complete = serializedObject.FindProperty("_complete");
        processing = serializedObject.FindProperty("_processing");
        safeMode = serializedObject.FindProperty("SafeMode");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        
        var mainSettings = target as MainSettings;

        num = EditorGUILayout.Popup("Start Language", num, Language.Languages);
        mainSettings.StartLanguage = Language.Languages[num];

        if (mainSettings.SelectedLanguages != null && mainSettings.SelectedLanguages.Length != Language.Languages.Length)
        {
            mainSettings.SelectedLanguages = new bool[Language.Languages.Length];
        }
        
        GUILayout.Label("Languages");
        for (int i = 0; i < Language.Languages.Length; i++)
        {
            EditorGUILayout.BeginHorizontal();
            mainSettings.SelectedLanguages[i] = GUILayout.Toggle(mainSettings.SelectedLanguages[i], Language.Languages[i]);
            EditorGUILayout.EndHorizontal();
        }
        
        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("All"))
        {
            for (int i = 0; i < mainSettings.SelectedLanguages.Length; i++)
            {
                mainSettings.SelectedLanguages[i] = true;
            }
        }
        if (GUILayout.Button("None"))
        {
            for (int i = 0; i < mainSettings.SelectedLanguages.Length; i++)
            {
                mainSettings.SelectedLanguages[i] = false;
            }
        }
        EditorGUILayout.EndHorizontal();

        if (GUILayout.Button("Translate"))
        {
            mainSettings.Translate();
        }

        if (processing.boolValue)
        {
            EditorGUILayout.LabelField("Processing!");
        }

        if (complete.boolValue)
        {
            EditorGUILayout.LabelField("Complete!");
        }
        EditorGUILayout.PropertyField(safeMode);
        
        EditorGUILayout.Space(50);
        
        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("Open All Scenes"))
        {
            mainSettings.OpenAllScenes();
        }
        if (mainSettings.Scenes.Count > 0 && GUILayout.Button("Close All Scenes"))
        {
            mainSettings.CloseScenes();
        }
        EditorGUILayout.EndHorizontal();
        if (GUILayout.Button("Add TextTranslator for all"))
        {
            mainSettings.AddComponentToAllTexts();
        }
        serializedObject.ApplyModifiedProperties();
    }
}
#endif