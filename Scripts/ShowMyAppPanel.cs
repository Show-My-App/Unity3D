using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ShowMyApp_API
{
    public class ShowMyAppPanel : MonoBehaviour
    {

        public Image Panel;
        public Image ImageQRCode;

        public Image OverlayQRCodeImage;
        public Image ShareImage;
        public Image BannerImage;
        public Image BannerIcon;
        public Image BottomButton;
        public Text BottomText;
        public Text QRCodeText;
        public Text ShareText;

        public ShowMyApp ShowMyAppInstance;

         public void InstallUI()
        {
            if (ShowMyAppInstance != null)
            {
                if (Panel != null)
                {
                    Panel.color = ShowMyAppInstance.DesignColorBackground;
                }
                if (OverlayQRCodeImage != null)
                {
                    OverlayQRCodeImage.color = ShowMyAppInstance.DesignColor;
                }
                if (ShareImage != null)
                {
                    ShareImage.color = ShowMyAppInstance.DesignColor;
                }
                if (BannerImage != null)
                {
                    BannerImage.color = ShowMyAppInstance.DesignColor;
                }
                if (ImageQRCode != null)
                {
                    ImageQRCode.color = ShowMyAppInstance.DesignColor;
                }
                if (BannerIcon != null)
                {
                    BannerIcon.color = ShowMyAppInstance.DesignColorBackground;
                }
                if (BottomText != null)
                {
                    BottomText.color = ShowMyAppInstance.DesignColorBackground;
                }
                if (BottomButton != null)
                {
                    BottomButton.color = ShowMyAppInstance.DesignColor;
                }
    
                if (QRCodeText != null)
                {
                    QRCodeText.color = ShowMyAppInstance.DesignColor;
                }

                if (ShareText != null)
                {
                    ShareText.color = ShowMyAppInstance.DesignColor;
                }
            }
        }
        void Start()
        {
            InstallUI();
                if (ImageQRCode != null)
                {
                    ShowMyAppInstance.InsertQRCode(ImageQRCode);
                }
        }

        public void Share()
        {
            if (ShowMyAppInstance != null)
            {
                ShowMyAppInstance.Share(delegate (ShowMyAppState sState)
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
        
        private void OnDrawGizmos()
        {
            InstallUI();
        }
    }
}
