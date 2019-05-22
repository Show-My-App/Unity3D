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
namespace BasicToolBox
{
    //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    public class BTBNativeDialogIOS
    {
        //-------------------------------------------------------------------------------------------------------------
#if (UNITY_IPHONE && !UNITY_EDITOR) || DEBUG_MODE
        //-------------------------------------------------------------------------------------------------------------
        [DllImport("__Internal")]
        private static extern void _BTB_ShowDialog(string sTitle, string sMessage, string sOK, string sNOK);
        //-------------------------------------------------------------------------------------------------------------
        [DllImport("__Internal")]
        private static extern void _BTB_ShowAlert(string sTitle, string sMessage, string sOK);
        //-------------------------------------------------------------------------------------------------------------
        [DllImport("BasicToolBoxOSX")]
        private static extern void _BTB_ShowShare(string sTitle, string sMessage, string sOK);
        //-------------------------------------------------------------------------------------------------------------
        [DllImport("__Internal")]
        private static extern void _BTB_DismissAlert();
        //-------------------------------------------------------------------------------------------------------------
#endif
        //-------------------------------------------------------------------------------------------------------------
        public static void ShowDialog(string title, string message, string yes, string no)
        {
#if (UNITY_IPHONE && !UNITY_EDITOR) || DEBUG_MODE
            _BTB_ShowDialog(title, message, yes, no);
#endif
        }
        //-------------------------------------------------------------------------------------------------------------
        public static void ShowAlert(string title, string message, string ok)
        {
#if (UNITY_IPHONE && !UNITY_EDITOR) || DEBUG_MODE
            _BTB_ShowAlert(title, message, ok);
#endif
        }
        //-------------------------------------------------------------------------------------------------------------
        public static void DismissAlert()
        {
#if (UNITY_IPHONE && !UNITY_EDITOR) || DEBUG_MODE
            _BTB_DismissAlert();
#endif
        }
        //-------------------------------------------------------------------------------------------------------------
    }
    //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
}
//=====================================================================================================================