using UnityEngine;
using System.Collections;

#if UNITY_EDITOR
using UnityEditor;
#endif
//=====================================================================================================================
namespace ShowMyApp_API
{
    //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    public class ShowMyAppShareIOS : MonoBehaviour
    {
        //-------------------------------------------------------------------------------------------------------------
        public string Message;
        public ShowMyAppShareOnCompleteBlock CompleteBlock;
        //-------------------------------------------------------------------------------------------------------------
        public static ShowMyAppShareIOS Create(string sMessage, ShowMyAppShareOnCompleteBlock sCompleteBlock)
        {
            ShowMyAppShareIOS tDialog = new GameObject("ShowMyAppIOS_GameObject").AddComponent<ShowMyAppShareIOS>();
            tDialog.Message = sMessage;
            tDialog.CompleteBlock = sCompleteBlock;
            tDialog.Initialization(tDialog.name, "OnShareCompletedCallback");
            return tDialog;
        }
        //-------------------------------------------------------------------------------------------------------------
        public void Initialization(string sGameObjectName, string sMethodCallback)
        {
            ShowMyAppNativeIOS.ShowShare(Message,sGameObjectName, sMethodCallback);
        }
        //-------------------------------------------------------------------------------------------------------------
        public void OnShareCompletedCallback(string sButtonIndex) // call from .mm! Don't change the name
        {
            if (CompleteBlock != null)
            {
                int tIndex = System.Convert.ToInt16(sButtonIndex);
                switch (tIndex)
                {
                    case 0:
                        CompleteBlock(ShowMyAppState.OK);
                        break;
                    case 1:
                        CompleteBlock(ShowMyAppState.NOK);
                        break;
                }
            }
            Destroy(gameObject);
        }
        //-------------------------------------------------------------------------------------------------------------
    }
    //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
}
//=====================================================================================================================
