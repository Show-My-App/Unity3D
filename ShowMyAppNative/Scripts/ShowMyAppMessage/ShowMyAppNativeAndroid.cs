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
        #if UNITY_ANDROID
        //-------------------------------------------------------------------------------------------------------------
        private AndroidJavaObject MyClass = null;
        private AndroidJavaObject Activity = null;
        //-------------------------------------------------------------------------------------------------------------
        public void Call(bool isStatic, string sMethodName, params object[] sArgs)
        {
            try {
                if (isStatic)
                {
                    GetActivityObject().Call("runOnUiThread", new AndroidJavaRunnable(() =>
                    {
                        GetMyClassObject().CallStatic(sMethodName, sArgs);
                    }));
                }
                else
                {
                    GetMyClassObject().Call(sMethodName, sArgs);
                }
            } catch (System.Exception ex) {
                Debug.LogWarning(ex.Message);
            }
        }
        //-------------------------------------------------------------------------------------------------------------
        public void ShowShare(string sMethodName, params object[] sArgs)
        {
            SetActivityInNativePlugin();
            GetMyClassObject().Call(sMethodName, sArgs);
            //GetMyClassObject().Call("ShowTargetInfo", sMethodName, 1f, 2f);

            /*AndroidJavaClass intentClass = new AndroidJavaClass("android.content.Intent");
            AndroidJavaObject intentObject = new AndroidJavaObject("android.content.Intent");
            intentObject.Call<AndroidJavaObject>("setAction", "ACTION_SEND");
            //AndroidJavaClass uriClass = new AndroidJavaClass("android.net.Uri");
            //AndroidJavaObject uriObject = uriClass.CallStatic<AndroidJavaObject>("parse", sArgs[0]);
            intentObject.Call<AndroidJavaObject>("putExtra", "EXTRA_TEXT", sArgs[0]);
            intentObject.Call<AndroidJavaObject>("setType", "text/plain");
            AndroidJavaObject chooser = intentClass.CallStatic<AndroidJavaObject>("createChooser", intentObject, "Share your new QRCode");

            GetActivityObject().Call("startActivity", chooser);*/
        }
        //-------------------------------------------------------------------------------------------------------------
        AndroidJavaObject GetMyClassObject()
        {
            if (MyClass == null)
            {
                MyClass = new AndroidJavaObject("com.idemobi.show_my_app.MyClass");
            }
            return MyClass;
        }
        //-------------------------------------------------------------------------------------------------------------
        AndroidJavaObject GetActivityObject()
        {
            if (Activity == null)
            {
                AndroidJavaClass tJclass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
                Activity = tJclass.GetStatic<AndroidJavaObject>("currentActivity");
            }
            return Activity;
        }
        //-------------------------------------------------------------------------------------------------------------
        void SetActivityInNativePlugin()
        {
            // Retrieve current Android Activity from the Unity Player
            // Pass reference to the current Activity into the native plugin,
            // using the 'setActivity' method that we defined in the ImageTargetLogger Java class
            GetMyClassObject().Call("setActivity", GetActivityObject());
        }
        //-------------------------------------------------------------------------------------------------------------
        #endif
    }
    //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
}
//=====================================================================================================================