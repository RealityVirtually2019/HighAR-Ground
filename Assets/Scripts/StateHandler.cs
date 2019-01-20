namespace HighAR
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class StateHandler : MonoBehaviour
    {
        private float speed;
        private bool movingToLocation;
        private float currentDistanceFromDestination;
        private Vector3 desiredPosition;
        private Vector3 heading;

        void Start()
        {
            movingToLocation= false;
        }

        public void SelectPerson(Vector3 newPosition)
        {
            desiredPosition = newPosition;
            heading = gameObject.transform.position - desiredPosition;
            currentDistanceFromDestination = heading.magnitude;
            movingToLocation = true;
        }

        void Update()
        {
            if (Input.GetKeyDown("space"))
            {
                SelectPerson(new Vector3(0,2,0));
            }
                if (movingToLocation)
            {
                if (currentDistanceFromDestination > 0)
                {
                    Vector3 currentPosition = gameObject.transform.position;

                    transform.Translate(heading * Time.deltaTime);
                    transform.localScale += new Vector3(0.0001F, 0.0001F, 0.0001F);

                    Vector3 newPosition = gameObject.transform.position;
                    float distanceMoved = (currentPosition - newPosition).magnitude;
                    currentDistanceFromDestination -= distanceMoved;
                }
                else
                {
                    movingToLocation = false;
                }
            }
        }
    }
}

