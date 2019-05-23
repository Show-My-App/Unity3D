#define DEBUG_MODE

using UnityEngine;
using System.Collections;

#if (UNITY_IPHONE && !UNITY_EDITOR) || DEBUG_MODE
using System.Runtime.InteropServices;
#endif

#if UNITY_EDITOR
using UnityEditor;
#endif
//=====================================================================================================================
namespace ShowMyApp_API
{
    //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    public class ShowMyAppNativeIOS
    {
        //-------------------------------------------------------------------------------------------------------------
#if (UNITY_IPHONE && !UNITY_EDITOR) || DEBUG_MODE
        //-------------------------------------------------------------------------------------------------------------
        [DllImport("__Internal")]
        private static extern void _ShowMyApp_ShowShare(string sMessage, string sGameObjectName, string sCallbackName);
        //-------------------------------------------------------------------------------------------------------------
#endif
        //-------------------------------------------------------------------------------------------------------------
        public static void ShowShare(string sMessage, string sGameObjectName, string sCallbackName)
        {
#if (UNITY_IPHONE && !UNITY_EDITOR) || DEBUG_MODE
            _ShowMyApp_ShowShare(sMessage, sGameObjectName, sCallbackName);
#endif
        }
        //-------------------------------------------------------------------------------------------------------------
    }
    //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
}
//=====================================================================================================================