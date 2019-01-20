namespace HighAR
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using HoloToolkit.Unity.InputModule;

    public class TerrainInteractionHandler : MonoBehaviour, IInputClickHandler
    {
        public void OnInputClicked(InputClickedEventData eventData)
        {
            WorldProperties.GlobalStateHandler.SelectMap(new Vector3(0,0,0));
        }
    }
}