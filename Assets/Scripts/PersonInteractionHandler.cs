namespace HighAR
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using HoloToolkit.Unity.InputModule;

    public class PersonInteractionHandler : MonoBehaviour, IFocusable, IInputClickHandler
    {
        public Person classPointer;

        void IFocusable.OnFocusEnter()
        {
            classPointer.HoverEvent();
        }

        void IFocusable.OnFocusExit()
        {
            classPointer.HoverEnd();
        }

        public void OnInputClicked(InputClickedEventData eventData)
        {
            classPointer.ClickEvent();
        }
    }
}
