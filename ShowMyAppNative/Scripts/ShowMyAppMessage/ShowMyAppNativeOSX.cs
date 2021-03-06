﻿#define DEBUG_MODE

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
namespace ShowMyApp_API
{
    //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    public class ShowMyAppNativeOSX
    {
        //-------------------------------------------------------------------------------------------------------------
#if UNITY_STANDALONE_OSX
        //-------------------------------------------------------------------------------------------------------------
        [DllImport("ShowMyAppOSX")]
        private static extern void _ShowMyApp_ShowShare(string sTitle, string sMessage, string sOK);
        //-------------------------------------------------------------------------------------------------------------
#endif
        //-------------------------------------------------------------------------------------------------------------
        public static void ShowShare(string sTitle, string sMessage, string sOk)
        {
#if UNITY_STANDALONE_OSX
            _ShowMyApp_ShowShare(sTitle, sMessage, sOk);
#endif
        }
        //-------------------------------------------------------------------------------------------------------------
    }
    //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
}
//=====================================================================================================================