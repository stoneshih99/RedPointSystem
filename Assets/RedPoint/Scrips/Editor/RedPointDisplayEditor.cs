using System;
using System.Collections.Generic;
using RedPoint.Scrips.Imp;
using UnityEditor;

namespace RedPoint.Scrips.Editor
{
    [CustomEditor(typeof(RedPointDisplayImp))]
    public class RedPointDisplayEditor : UnityEditor.Editor
    {
        private SerializedProperty _displayIndex;
        private SerializedProperty _displayTextMesPro;
        private SerializedProperty _displayText;
        private SerializedProperty _displayImage;

        private Dictionary<ERedPointDisplayType, Action> _action;

        /// <summary>
        /// connect to values.
        /// </summary>
        private void OnEnable()
        {
            _displayIndex = serializedObject.FindProperty("displayIndex");
            _displayTextMesPro = serializedObject.FindProperty("displayTextMesPro");
            _displayText = serializedObject.FindProperty("displayText");
            _displayImage = serializedObject.FindProperty("displayImage");

            SetupMapping();
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            EditorGUILayout.PropertyField(_displayIndex, true);
            var idx = _displayIndex.enumValueIndex;
            var e = (ERedPointDisplayType) idx;
            _action[e]?.Invoke();
            serializedObject.ApplyModifiedProperties();
        }

        private void SetupMapping()
        {
            _action = new Dictionary<ERedPointDisplayType, Action>();
            
            _action.Add(ERedPointDisplayType.Text, delegate
            {
                EditorGUILayout.PropertyField(_displayText, true);
            });
            _action.Add(ERedPointDisplayType.TextMeshPro, delegate
            {
                EditorGUILayout.PropertyField(_displayTextMesPro, true);
            });
            _action.Add(ERedPointDisplayType.Image, delegate
            {
                EditorGUILayout.PropertyField(_displayImage, true);
            });
            _action.Add(ERedPointDisplayType.TextAndImage, delegate
            {
                EditorGUILayout.PropertyField(_displayText, true);
                EditorGUILayout.PropertyField(_displayImage, true);
            });
            _action.Add(ERedPointDisplayType.TextMeshProAndImage, delegate
            {
                EditorGUILayout.PropertyField(_displayTextMesPro, true);
                EditorGUILayout.PropertyField(_displayImage, true);
            });
            
        }
    }
}