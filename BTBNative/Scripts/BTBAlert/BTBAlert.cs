using UnityEngine;
using System.Collections;

#if UNITY_EDITOR
using UnityEditor;
#endif
//=====================================================================================================================
namespace BasicToolBox
{
    //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    public delegate void BTBAlertOnCompleteBlock(BTBMessageState state);
    //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    public class BTBAlert
    {
        //-------------------------------------------------------------------------------------------------------------
        const string K_OK = "OK";
        //-------------------------------------------------------------------------------------------------------------
        public static BTBAlert Alert(string sTitle, string sMessage, string sOK = K_OK, BTBAlertOnCompleteBlock sCompleteBlock = null)
        {
            BTBAlert rReturn = new BTBAlert(sTitle, sMessage, sOK, null);
            return rReturn;
        }
        //-------------------------------------------------------------------------------------------------------------
        public BTBAlert(string sTitle, string sMessage, string sOK = K_OK)
        {
            Initialization(sTitle, sMessage, sOK, null);
        }
        //-------------------------------------------------------------------------------------------------------------
        public BTBAlert(string sTitle, string sMessage, string sOK, BTBAlertOnCompleteBlock sCompleteBlock = null )
        {
            Initialization(sTitle, sMessage, sOK,sCompleteBlock);
        }
        //-------------------------------------------------------------------------------------------------------------
        private void Initialization(string sTitle, string sMessage, string sOK, BTBAlertOnCompleteBlock sCompleteBlock = null)
        {
#if UNITY_EDITOR
            if (EditorUtility.DisplayDialog(sTitle, sMessage, sOK) == true)
            {
                if (sCompleteBlock != null)
                {
                    sCompleteBlock(BTBMessageState.OK);
                }
            }
#else
#if UNITY_IPHONE
            BTBAlertIOS.Create(sTitle, sMessage, sOK, sCompleteBlock);
#elif UNITY_ANDROID
            BTBAlertAndroid.Create(sTitle, sMessage, sOK, sCompleteBlock);
#elif UNITY_STANDALONE_OSX
            BTBAlertOSX.Create(sTitle, sMessage, sOK, sCompleteBlock);
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
