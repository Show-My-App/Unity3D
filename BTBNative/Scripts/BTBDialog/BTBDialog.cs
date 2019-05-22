using UnityEngine;
using System.Collections;

#if UNITY_EDITOR
using UnityEditor;
#endif
//=====================================================================================================================
namespace BasicToolBox
{
    //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    public delegate void BTBDialogOnCompleteBlock(BTBMessageState state);
    //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    public class BTBDialog
    {
        //-------------------------------------------------------------------------------------------------------------
        public static BTBDialog Dialog(string sTitle, string sMessage, string sOK = "YES", string sNOK = "NO", BTBDialogOnCompleteBlock sCompleteBlock = null)
        {
            BTBDialog rDialog = new BTBDialog(sTitle, sMessage, sOK, sNOK, sCompleteBlock);
            return rDialog;
        }
        //-------------------------------------------------------------------------------------------------------------
        public BTBDialog(string sTitle, string sMessage, string sOK = "YES", string sNOK = "NO")
        {
            Initialization(sTitle, sMessage, sOK, sNOK, null);
        }
        //-------------------------------------------------------------------------------------------------------------
        public BTBDialog(string sTitle, string sMessage, string sOK, string sNOK, BTBDialogOnCompleteBlock sCompleteBlock = null)
        {
            Initialization(sTitle, sMessage, sOK,sNOK, sCompleteBlock);
        }
        //-------------------------------------------------------------------------------------------------------------
        private void Initialization(string sTitle, string sMessage, string sOK, string sNOK, BTBDialogOnCompleteBlock sCompleteBlock = null)
        {
#if UNITY_EDITOR
            if (EditorUtility.DisplayDialog(sTitle, sMessage, sOK, sNOK) == true)
            {
                if (sCompleteBlock != null)
                {
                    sCompleteBlock(BTBMessageState.OK);
                }
            }
            else
            {
                if (sCompleteBlock != null)
                {
                    sCompleteBlock(BTBMessageState.NOK);
                }
            }
#else
#if UNITY_IPHONE
            BTBDialogIOS.Create(sTitle, sMessage, sOK, sNOK, sCompleteBlock);
#elif UNITY_ANDROID
            BTBDialogAndroid.Create(sTitle, sMessage, sOK, sNOK, sCompleteBlock);
#elif UNITY_STANDALONE_OSX
            BTBDialogOSX.Create(sTitle, sMessage, sOK, sNOK, sCompleteBlock);
#elif UNITY_STANDALONE_WIN
            Debug.Log("ALERT " + sTitle +" " + sMessage);
#elif UNITY_STANDALONE_LINUX
            Debug.Log("ALERT " + sTitle +" " + sMessage);
#else
            Debug.Log("ALERT " + sTitle +" " + sMessage);
#endif

#endif
        }
        //-------------------------------------------------------------------------------------------------------------
    }
    //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
}
//=====================================================================================================================
