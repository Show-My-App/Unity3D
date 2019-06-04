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
        public static void Call(bool isStatic, string sMethodName, params object[] sArgs)
        {
            #if UNITY_ANDROID //&& !UNITY_EDITOR
            try {
                AndroidJavaObject bridge = new AndroidJavaObject("com.idemobi.show_my_app.MyClass");
                AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
                AndroidJavaObject act = jc.GetStatic<AndroidJavaObject>("currentActivity");

                if (isStatic)
                {
                    act.Call("runOnUiThread", new AndroidJavaRunnable(() =>
                    {
                        bridge.CallStatic(sMethodName, sArgs);
                    }));
                }
                else
                {
                    bridge.Call(sMethodName, sArgs);
                }
            } catch (System.Exception ex) {
                Debug.LogWarning(ex.Message);
            }
            #endif
        }
        //-------------------------------------------------------------------------------------------------------------
        public static void ShowShare(string sMethodName, string sParams)
        {
            Call(false, sMethodName, sParams);
        }
        //-------------------------------------------------------------------------------------------------------------
    }
    //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
}
//=====================================================================================================================