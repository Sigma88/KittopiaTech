﻿using System;
using KSP.UI;
using UnityEngine;

namespace KittopiaTech.UI.Framework
{
    public class ClickThroughBlocker : MonoBehaviour
    {
        private Boolean _locked;

        void Update()
        {
            Boolean inputLocked = UIMasterController.Instance &&
                                   RectTransformUtility.RectangleContainsScreenPoint(GetComponent<RectTransform>(), Input.mousePosition,
                                       UIMasterController.Instance.uiCamera);
            if (inputLocked && !_locked)
            {
                _locked = true;
                InputLockManager.SetControlLock(ControlTypes.ALLBUTCAMERAS,
                    typeof(ClickThroughBlocker).Assembly.FullName);
            }
            else if (!inputLocked && _locked)
            {
                _locked = false;
                InputLockManager.RemoveControlLock(typeof(ClickThroughBlocker).Assembly.FullName);
            }
        }
    }
}