// ====================================================================================================================
//
//  ideMobi 2019©
//
//  Date        2019-5-28 14:00:00
//  Author      Kortex (Jean-François CONTART) 
//  Email       jfcontart@idemobi.com
//  Project     NetWorkedData for Unity3D
//
//  All rights reserved by ideMobi
//
// ====================================================================================================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ShowMyApp_API
{
    [RequireComponent(typeof(ShowMyApp))]
    public class ShowMyAppButton : MonoBehaviour
    {
        private ShowMyApp ShowMyAppComponent;
        // Start is called before the first frame update

        public void InstallUI()
        {
            ShowMyAppComponent = GetComponent<ShowMyApp>();

            foreach (Text tText in GetComponentsInChildren<Text>())
            {
                tText.color = ShowMyAppComponent.DesignColor;
            }
            foreach (Image tImage in GetComponents<Image>())
            {
                tImage.color = ShowMyAppComponent.DesignColor;
            }
        }

        void Start()
        {
            InstallUI();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void ShareAction()
        {
            ShowMyAppComponent.Share();
        }

        private void OnDrawGizmos()
        {
            InstallUI();
        }
    }
}
