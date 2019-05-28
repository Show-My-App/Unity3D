
using UnityEngine;
using System.Collections;

#if UNITY_EDITOR
using UnityEditor;
#endif
//=====================================================================================================================
namespace ShowMyApp_API
{
    //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    public delegate void ShowMyAppShareOnCompleteBlock(ShowMyAppState state);
    //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    public class ShowMyAppShare
    {
        //-------------------------------------------------------------------------------------------------------------
        public static ShowMyAppShare Share(string sMessage, ShowMyAppShareOnCompleteBlock sCompleteBlock)
        {
            ShowMyAppShare rReturn = new ShowMyAppShare(sMessage, sCompleteBlock);
            return rReturn;
        }
        //-------------------------------------------------------------------------------------------------------------
        public ShowMyAppShare(string sMessage, ShowMyAppShareOnCompleteBlock sCompleteBlock)
        {
            Initialization(sMessage, sCompleteBlock);
        }
        //-------------------------------------------------------------------------------------------------------------
        private void Initialization(string sMessage, ShowMyAppShareOnCompleteBlock sCompleteBlock = null)
        {
#if UNITY_EDITOR
            bool tReturn = EditorUtility.DisplayDialog("Share not working in editor", sMessage, "OK", "NOK");
            if (tReturn == true)
            {
                sCompleteBlock?.Invoke(ShowMyAppState.OK);
            }
            else
            {
                sCompleteBlock?.Invoke(ShowMyAppState.NOK);
            }
#else
#if UNITY_IPHONE
            ShowMyAppShareIOS.Create(sMessage, sCompleteBlock);
#elif UNITY_ANDROID
            ShowMyAppShareAndroid.Create(sMessage, sCompleteBlock);
#elif UNITY_STANDALONE_OSX
            ShowMyAppShareOSX.Create(sMessage, sCompleteBlock);
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
