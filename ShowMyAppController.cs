using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ShowMyApp_API
{
    public class ShowMyAppController : MonoBehaviour
    {
        public Image ImageQRCode;
        public ShowMyApp ShowMyAppInstance;

        void Start()
        {
            if (ShowMyAppInstance != null)
            {
                ShowMyAppInstance.InsertQRCode(ImageQRCode);
            }
        }

        public void Share()
        {
            if (ShowMyAppInstance != null)
            {
                ShowMyAppInstance.Share("Try this App!", delegate (ShowMyAppState sState)
                {
                    if (sState == ShowMyAppState.OK)
                    {
                        Debug.Log("Sharing successed!");
                    }
                    else
                    {
                        Debug.Log("Sharing cancelled or in error!");
                    }
                });
            }
        }

        public void Powered()
        {
            if (ShowMyAppInstance != null)
            {
                ShowMyAppInstance.Powered();
            }
        }
    }
}
