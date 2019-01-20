namespace HighAR
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class StateHandler : MonoBehaviour
    {
        public enum AppState {Zooming_Out, Zooming_In, Person_View, Map_View}; // These are the possible values for the controller's state
        public static AppState currentState; // We use this to determine what state the controller is in - and what actions are available

        private float speed;
        private bool movingToLocation;
        private bool zoomTo;
        private float currentDistanceFromDestination;
        private Vector3 desiredPosition;
        private Vector3 heading;

        void Start()
        {
            zoomTo = false;
            movingToLocation= false;
        }

        public void SelectMap(Vector3 newPosition)
        {
            if(currentState == AppState.Person_View)
            {
                desiredPosition = newPosition;
                heading = gameObject.transform.position - desiredPosition;
                currentDistanceFromDestination = heading.magnitude;
                movingToLocation = true;
                currentState = AppState.Zooming_Out;
            }
        }

        public void SelectPerson(Vector3 newPosition)
        {
            desiredPosition = newPosition;
            heading = gameObject.transform.position - desiredPosition;
            currentDistanceFromDestination = heading.magnitude;
            movingToLocation = true;
            if (currentState == AppState.Map_View)
            {
                currentState = AppState.Zooming_In;
            }     
        }

        void Update()
        {
            if (Input.GetKeyDown("space") && currentState == AppState.Map_View)
            {
                SelectPerson(new Vector3(0, 2, 0));
            } else if (Input.GetKeyDown("space") && currentState == AppState.Person_View)
            {
                SelectMap(new Vector3(0, 0, 0));
            }

            if (movingToLocation)
            {
                if (currentDistanceFromDestination > 0)
                {
                    Vector3 currentPosition = gameObject.transform.position;

                    transform.Translate(heading * Time.deltaTime);

                    Vector3 newPosition = gameObject.transform.position;

                    float distanceMoved = (currentPosition - newPosition).magnitude;
                    currentDistanceFromDestination -= distanceMoved;
                }
                else
                {
                    movingToLocation = false;
                }
            }

            if (currentState == AppState.Zooming_In) {
                if (transform.localScale.x < 0.003)
                {
                    transform.localScale += new Vector3(0.0001F, 0.0001F, 0.0001F);
                }
                else
                {
                    currentState = AppState.Person_View;
                }
            }

            if (currentState == AppState.Zooming_Out) { 
                if (transform.localScale.x > 0.001)
                {
                    transform.localScale -= new Vector3(0.0001F, 0.0001F, 0.0001F);
                }
                else
                {
                    currentState = AppState.Map_View;
                }
            }
        }
    }
}

