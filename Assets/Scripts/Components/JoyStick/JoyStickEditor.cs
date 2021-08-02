using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(JoyStick), false)]
public class JoyStickEditor : Editor
{
    private SerializedProperty m_Stick;
    private SerializedProperty m_Arrow;
    private SerializedProperty m_Background;

    private void OnEnable()
    {
        m_Stick = serializedObject.FindProperty("stick");
        m_Arrow = serializedObject.FindProperty("arrow");
        m_Background = serializedObject.FindProperty("background");
    }

    public override void OnInspectorGUI()
    {
        // base.OnInspectorGUI();
        serializedObject.Update();

        EditorGUILayout.PropertyField(m_Background);
        if (serializedObject.ApplyModifiedProperties())
        {
            var joyStick = (JoyStick) target;
            joyStick.SetBackground();
        }

        EditorGUILayout.PropertyField(m_Stick);
        serializedObject.ApplyModifiedProperties();

        EditorGUILayout.PropertyField(m_Arrow);
        serializedObject.ApplyModifiedProperties();
    }
}