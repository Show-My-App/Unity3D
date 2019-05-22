#define DEBUG_MODE

using System;
using UnityEngine;
using System.Collections;

#if UNITY_STANDALONE_OSX
using System.Runtime.InteropServices;
#endif

#if UNITY_EDITOR
using UnityEditor;
#endif
//=====================================================================================================================
// try with https://www.youtube.com/watch?v=Q2dDK0ulDYY

namespace BasicToolBox
{
    //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    public class BTBNativeDialogOSX
    {
        //-------------------------------------------------------------------------------------------------------------
#if UNITY_STANDALONE_OSX
        //-------------------------------------------------------------------------------------------------------------
        public delegate void UnityCallbackDelegate(IntPtr sObjectName, IntPtr sCommandName, IntPtr sCommandData);
        [DllImport("BasicToolBoxOSX")]
        public static extern void ConnectCallback([MarshalAs(UnmanagedType.FunctionPtr)] UnityCallbackDelegate callbackMethod);
        //-------------------------------------------------------------------------------------------------------------
        [DllImport("BasicToolBoxOSX")]
        private static extern void _BTB_ShowDialog(string sTitle, string sMessage, string sOK, string sNOK);
        //-------------------------------------------------------------------------------------------------------------
        [DllImport("BasicToolBoxOSX")]
        private static extern void _BTB_ShowAlert(string sTitle, string sMessage, string sOK);
        //-------------------------------------------------------------------------------------------------------------
        [DllImport("BasicToolBoxOSX")]
        private static extern void _BTB_ShowShare(string sTitle, string sMessage, string sOK);
        //-------------------------------------------------------------------------------------------------------------
        //[DllImport("BasicToolBoxOSX")]
        //private static extern void _BTB_DismissAlert();
        //-------------------------------------------------------------------------------------------------------------
#endif
        //-------------------------------------------------------------------------------------------------------------
        public static void ShowDialog(string title, string message, string yes, string no)
        {
            //Debug.Log("ShowDialog()");
#if UNITY_STANDALONE_OSX
            _BTB_ShowDialog(title, message, yes, no);
#endif
        }
        //-------------------------------------------------------------------------------------------------------------
        public static void ShowAlert(string title, string message, string ok)
        {
#if UNITY_STANDALONE_OSX
            _BTB_ShowAlert(title, message, ok);
#endif
        }
        //-------------------------------------------------------------------------------------------------------------
        public static void ShowShare(string title, string message, string ok)
        {
#if UNITY_STANDALONE_OSX
            _BTB_ShowShare(title, message, ok);
#endif
        }
        //-------------------------------------------------------------------------------------------------------------
//        public static void DismissAlert()
//        {
//#if UNITY_STANDALONE_OSX
//            _BTB_DismissAlert();
//#endif
        //}
        //-------------------------------------------------------------------------------------------------------------
    }
    //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
}
//=====================================================================================================================