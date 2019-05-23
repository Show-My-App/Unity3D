using UnityEngine;
using System.Collections;

#if UNITY_EDITOR
using UnityEditor;
#endif
//=====================================================================================================================
namespace ShowMyApp_API
{
    //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    public class ShowMyAppNativeAndroid
    {
        //-------------------------------------------------------------------------------------------------------------
        public static void CallStatic(string methodName, params object[] args)
        {
#if UNITY_ANDROID && !UNITY_EDITOR
        try
        {
            string CLASS_NAME = "com.idemobi.showmyapp.ShowMyAppAndroid";
            AndroidJavaObject bridge = new AndroidJavaObject(CLASS_NAME);

            AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer"); 
            AndroidJavaObject act = jc.GetStatic<AndroidJavaObject>("currentActivity"); 
            
            act.Call("runOnUiThread", new AndroidJavaRunnable(() =>
            {
                bridge.CallStatic(methodName, args);
            }));

        } catch (System.Exception ex)
        {
            Debug.LogWarning(ex.Message);
        }
#endif
        }
        //-------------------------------------------------------------------------------------------------------------
        public static void ShowShare(string title, string message, string ok)
        {
            CallStatic("ShowShare", title, message, ok);
        }
        //-------------------------------------------------------------------------------------------------------------
    }
    //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
}
//=====================================================================================================================