using UnityEngine;
using UnityEngine;
using HoloToolkit.Unity.InputModule;
//public class CityMover : MonoBehaviour, IFocusable, IInputClickHandler
public class CityMover : MonoBehaviour
{
    public GameObject CityCenter;
    public Animator zoomAnimator;
    //public GameObject homePosition;
    public GameObject desiredPosition;
    public float speed;
    public bool moveToLocation;
    public float currentDistance;
    Vector3 HeadingTo;
    

	// Use this for initialization
	void Start () {
        //speed = 1f;
        moveToLocation = false;
        currentDistance = 0;
        
    }

    //public void OnInputClicked(InputClickedEventData eventData)
    


        // Update is called once per frame
        void Update () {
        //Debug.Log(CityCenter.transform.position);

        
        if (Input.GetKeyDown("space"))
        {
            moveToLocation = true;
            
            HeadingTo = gameObject.transform.position - desiredPosition.transform.position;
            currentDistance = HeadingTo.magnitude;
        }

        if (moveToLocation)
        {
            if (currentDistance > 0)
            {
                Vector3 currentPosition = gameObject.transform.position;

                transform.Translate(HeadingTo * Time.deltaTime);

                Vector3 newPosition = gameObject.transform.position;
                float distanceMoved = (currentPosition - newPosition).magnitude;
                currentDistance -= distanceMoved;
                Debug.Log("the city moved");
                zoomAnimator.SetBool("Zoom", true);
            }
            else
            {
                moveToLocation = false;
                
            }
        }
	}

    void TriggerZoom()
    {
        zoomAnimator.SetBool("Zoom", true);

    }


}
