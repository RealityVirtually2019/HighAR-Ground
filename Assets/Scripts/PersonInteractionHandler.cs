namespace HighAR
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using HoloToolkit.Unity.InputModule;

    public class PersonInteractionHandler : MonoBehaviour, IInputClickHandler
    {

        //public void OnFocusEnter()
        //{
        //    Rotating = true;
        //}

        //public void OnFocusExit()
        //{
        //    Rotating = false;
        //}  

        public Person classPointer;

        public void OnInputClicked(InputClickedEventData eventData)
        {
            classPointer.ClickEvent();
        }
    }
}
