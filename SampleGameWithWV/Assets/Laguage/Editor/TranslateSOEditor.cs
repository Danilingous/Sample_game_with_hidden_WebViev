#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(TranslateSO))]
[CanEditMultipleObjects]
public class TranslateSOEditor : Editor
{
    private int num;

    private void OnEnable()
    {
    }
    
    public override void OnInspectorGUI()
    {
        GUIStyle labelStyle = new GUIStyle
        {
            fontSize = 16,
            fontStyle = FontStyle.Bold,
            normal = new GUIStyleState()
            {
                textColor = Color.green
            }
        };

        serializedObject.Update();
        
        var main = target as TranslateSO;
        
        num = EditorGUILayout.Popup("Start Language", num, Language.Languages);
        main.LanguageToTranslate = Language.Languages[num];
        main.TextToTranslate = EditorGUILayout.TextArea(main.TextToTranslate, EditorStyles.textArea);
        
        if (main.SelectedLanguages != null && main.SelectedLanguages.Length != Language.Languages.Length)
        {
            main.SelectedLanguages = new bool[Language.Languages.Length];
        }
        
        GUILayout.Label("Languages");
        for (int i = 0; i < Language.Languages.Length; i++)
        {
            EditorGUILayout.BeginHorizontal();
            main.SelectedLanguages[i] = GUILayout.Toggle(main.SelectedLanguages[i], Language.Languages[i]);
            EditorGUILayout.EndHorizontal();
        }
        
        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("All"))
        {
            for (int i = 0; i < main.SelectedLanguages.Length; i++)
            {
                main.SelectedLanguages[i] = true;
            }
        }
        if (GUILayout.Button("None"))
        {
            for (int i = 0; i < main.SelectedLanguages.Length; i++)
            {
                main.SelectedLanguages[i] = false;
            }
        }
        EditorGUILayout.EndHorizontal();
        
        if (GUILayout.Button("Translate"))
        {
            main.Translate();
        }

        for (int i = 0; i < main.Translates.Length; i++)
        {
            EditorGUILayout.LabelField(main.Translates[i].Language, labelStyle);

            EditorGUILayout.Separator();

            EditorGUI.DrawRect(EditorGUILayout.GetControlRect(false, 1), Color.gray);
            EditorGUILayout.TextArea(main.Translates[i].Text, EditorStyles.wordWrappedLabel);

            if (GUILayout.Button("Copy"))
                EditorGUIUtility.systemCopyBuffer = main.Translates[i].Text;

            EditorGUI.DrawRect(EditorGUILayout.GetControlRect(false, 1), Color.gray);
            EditorGUILayout.Separator();
        }
        
        serializedObject.ApplyModifiedProperties();
    }
}

#endif