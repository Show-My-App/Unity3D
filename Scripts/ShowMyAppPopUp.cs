
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ShowMyApp_API
{
    public enum ShowMyAppPopUpAnimation : int
    {
        Bottom,
        Top,
        Left,
        Right,
        Center,
    }
    [RequireComponent(typeof(ShowMyApp))]
    [RequireComponent(typeof(Animator))]
    public class ShowMyAppPopUp : MonoBehaviour
    {
        Animator PanelAnimator;
        ShowMyAppPanel ShowMyAppPanelInstance;
        public ShowMyAppPopUpAnimation AnimationStyle;
        // Start is called before the first frame update
        public void InstallUI()
        {
            ShowMyAppPanelInstance = GetComponentInChildren<ShowMyAppPanel>();
            ShowMyAppPanelInstance.InstallUI();
        }
        void Start()
        {
           PanelAnimator = GetComponent<Animator>();
           InstallUI();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void ShareAction()
        {
            PanelAnimator.Play(AnimationStyle.ToString()+"_Enter",0);

        }
        
        public void Close()
        {
            PanelAnimator.Play(AnimationStyle.ToString()+"_Exit",0);

        }
        
        private void OnDrawGizmos()
        {
            InstallUI();
        }
    }
}