
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace ShowMyApp_API
{
    [CustomEditor(typeof(ShowMyApp))]
    public class ShowMyAppInspector : Editor
    {

        SerializedProperty m_AppName;
        SerializedProperty m_Message;
        SerializedProperty m_Design;
        SerializedProperty m_DesignColor;
        SerializedProperty m_DesignColorBackground;
        SerializedProperty m_Tiny;
        SerializedProperty m_OneIconOnly;

        SerializedProperty m_ReferencedUser;
        SerializedProperty m_ReccordID;
        
        SerializedProperty m_iOS_iPhone_BundleID;
        SerializedProperty m_iOS_iPad_BundleID;
        SerializedProperty m_macOS_BundleID;
        SerializedProperty m_tvOS_BundleID;
        
        SerializedProperty m_android_BundleID;
        SerializedProperty m_android_Tablet_BundleID;
        
        SerializedProperty m_windows_BundleID;
        SerializedProperty m_windows_Phone_BundleID;
        
        SerializedProperty m_steam_BundleID;

        void OnEnable()
        {
            // Fetch the objects from the GameObject script to display in the inspector
            m_AppName = serializedObject.FindProperty("AppName");
            m_Message = serializedObject.FindProperty("Message");
            m_Design = serializedObject.FindProperty("Design");
            m_DesignColor = serializedObject.FindProperty("DesignColor");
            m_DesignColorBackground = serializedObject.FindProperty("DesignColorBackground");
            m_Tiny = serializedObject.FindProperty("Tiny");
            m_OneIconOnly = serializedObject.FindProperty("OneIconOnly");

            m_ReferencedUser = serializedObject.FindProperty("ReferencedUser");
            m_ReccordID = serializedObject.FindProperty("ReccordID");
            
            m_iOS_iPhone_BundleID = serializedObject.FindProperty("iOS_iPhone_BundleID");
            m_iOS_iPad_BundleID = serializedObject.FindProperty("iOS_iPad_BundleID");
            m_macOS_BundleID = serializedObject.FindProperty("macOS_BundleID");
            m_tvOS_BundleID = serializedObject.FindProperty("tvOS_BundleID");
            
            m_android_BundleID = serializedObject.FindProperty("android_BundleID");
            m_android_Tablet_BundleID = serializedObject.FindProperty("android_Tablet_BundleID");

            m_windows_BundleID = serializedObject.FindProperty("windows_BundleID");
            m_windows_Phone_BundleID = serializedObject.FindProperty("windows_Phone_BundleID");

            m_steam_BundleID = serializedObject.FindProperty("steam_BundleID");


            //[Header("Apple©")]
            //[Tooltip("The App's Identifiant Apple in App Store Connect (example : 123456789)")]
            //public string iOS_iPhone_BundleID; // &a=xxxxx
            //[Tooltip("The App's Identifiant Apple in App Store Connect (example : 123456789)")]
            //public string iOS_iPad_BundleID; // &b=xxxxx
            //[Tooltip("The App's Identifiant Apple in App Store Connect (example : 123456789)")]
            //public string macOS_BundleID; // &m=xxxxx
            //[Tooltip("The App's Identifiant Apple in App Store Connect (example : 123456789)")]
            //public string tvOS_BundleID; // &v=xxxxx

            //[Header("Google©")]
            //[Tooltip("The App's bundle id in Google Play (example : com.company.app)")]
            //public string android_BundleID;  // &g=xxxxx
            //[Tooltip("The App's bundle id in Google Play (example : com.company.app)")]
            //public string android_Tablet_BundleID;  // &h=xxxxx
        }

        public override void OnInspectorGUI()
        {
            this.serializedObject.Update();

            GUILayout.Label(new GUIContent("General informations"), EditorStyles.boldLabel);
            EditorGUI.indentLevel++;
            EditorGUILayout.PropertyField(m_AppName, new GUIContent("Name of App"), GUILayout.Height(20));
            EditorGUILayout.PropertyField(m_Message, new GUIContent("Default message"));
            EditorGUILayout.PropertyField(m_Design, new GUIContent("Design"));
            EditorGUILayout.PropertyField(m_DesignColor, new GUIContent("Color"));
            EditorGUILayout.PropertyField(m_DesignColorBackground, new GUIContent("Background Color"));
            EditorGUILayout.PropertyField(m_Tiny, new GUIContent("Tiny URL"));
            EditorGUILayout.PropertyField(m_OneIconOnly, new GUIContent("One Icon Only"));
            EditorGUI.indentLevel--;

            GUILayout.Label(new GUIContent("Use Show-My-App's Account"), EditorStyles.boldLabel);
            EditorGUI.indentLevel++;
            EditorGUILayout.PropertyField(m_ReferencedUser, new GUIContent("Use Account"));
            EditorGUI.BeginDisabledGroup(!m_ReferencedUser.boolValue);

            EditorGUILayout.PropertyField(m_ReccordID, new GUIContent("Reccord ID"));
            EditorGUI.EndDisabledGroup();
            EditorGUI.indentLevel--;

            GUILayout.Label(new GUIContent("Apple© Informations"), EditorStyles.boldLabel);
            EditorGUI.indentLevel++;
            EditorGUI.BeginDisabledGroup(m_ReferencedUser.boolValue);
            EditorGUILayout.PropertyField(m_iOS_iPhone_BundleID, new GUIContent("iOS AppleID"));
            EditorGUILayout.PropertyField(m_iOS_iPad_BundleID, new GUIContent("iOS iPad AppleID"));
            EditorGUILayout.PropertyField(m_macOS_BundleID, new GUIContent("macOS AppleID"));
            EditorGUILayout.PropertyField(m_tvOS_BundleID, new GUIContent("tvOS AppleID"));
            EditorGUI.EndDisabledGroup();
            EditorGUI.indentLevel--;

            GUILayout.Label(new GUIContent("Google© Informations"), EditorStyles.boldLabel);
            EditorGUI.indentLevel++;
            EditorGUI.BeginDisabledGroup(m_ReferencedUser.boolValue);
            EditorGUILayout.PropertyField(m_android_BundleID, new GUIContent("Android bundle ID"));
            EditorGUILayout.PropertyField(m_android_Tablet_BundleID, new GUIContent("Android Tablet bundle ID"));
            EditorGUI.EndDisabledGroup();
            EditorGUI.indentLevel--;

            GUILayout.Label(new GUIContent("Microsoft© Informations"), EditorStyles.boldLabel);
            EditorGUI.indentLevel++;
            EditorGUI.BeginDisabledGroup(m_ReferencedUser.boolValue);
            EditorGUILayout.PropertyField(m_windows_BundleID, new GUIContent("Window ID"));
            EditorGUILayout.PropertyField(m_windows_Phone_BundleID, new GUIContent("Window Phone ID"));
            EditorGUI.EndDisabledGroup();
            EditorGUI.indentLevel--;

            GUILayout.Label(new GUIContent("SteamOS© Informations"), EditorStyles.boldLabel);
            EditorGUI.indentLevel++;
            EditorGUI.BeginDisabledGroup(m_ReferencedUser.boolValue);
            EditorGUILayout.PropertyField(m_steam_BundleID, new GUIContent("Steam App ID"));
            EditorGUI.EndDisabledGroup();
            EditorGUI.indentLevel--;

            this.serializedObject.ApplyModifiedProperties();
        }
    }
}
