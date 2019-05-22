using UnityEngine;
using System.Collections;

#if UNITY_EDITOR
using UnityEditor;
#endif
//=====================================================================================================================
namespace BasicToolBox
{
    //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    public delegate void BTBShareOnCompleteBlock(BTBMessageState state);
    //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    public class BTBShare
    {
        //-------------------------------------------------------------------------------------------------------------
        const string K_OK = "OK";
        //-------------------------------------------------------------------------------------------------------------
        public static BTBShare Share(string sTitle, string sMessage, string sOK = K_OK, BTBShareOnCompleteBlock sCompleteBlock = null)
        {
            BTBShare rReturn = new BTBShare(sTitle, sMessage, sOK, null);
            return rReturn;
        }
        //-------------------------------------------------------------------------------------------------------------
        public BTBShare(string sTitle, string sMessage, string sOK = K_OK)
        {
            Initialization(sTitle, sMessage, sOK, null);
        }
        //-------------------------------------------------------------------------------------------------------------
        public BTBShare(string sTitle, string sMessage, string sOK, BTBShareOnCompleteBlock sCompleteBlock = null )
        {
            Initialization(sTitle, sMessage, sOK,sCompleteBlock);
        }
        //-------------------------------------------------------------------------------------------------------------
        private void Initialization(string sTitle, string sMessage, string sOK, BTBShareOnCompleteBlock sCompleteBlock = null)
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
            BTBShareIOS.Create(sTitle, sMessage, sOK, sCompleteBlock);
#elif UNITY_ANDROID
            BTBShareAndroid.Create(sTitle, sMessage, sOK, sCompleteBlock);
#elif UNITY_STANDALONE_OSX
            BTBShareOSX.Create(sTitle, sMessage, sOK, sCompleteBlock);
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
