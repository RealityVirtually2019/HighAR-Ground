using UnityEngine;

public class CityMover : MonoBehaviour {
    public GameObject CityCenter;
    //public GameObject homePosition;
    public GameObject desiredPosition;
    public float speed;
    public bool moveToLocation;
    public float currentDistance;
    Vector3 HeadingTo;

	// Use this for initialization
	void Start () {
        speed = 1f;
        //desiredPosition = new Vector3(5f, 0, 0);
        //currentPosition = new Vector3(0, 0, 0);
        Debug.Log(CityCenter.transform.position);
        // FlyBy(currentPosition, desiredPosition);
        //CityCenter.transform.position = homePosition.transform.position;
        moveToLocation = false;
        currentDistance = 0;
    }
	
	// Update is called once per frame
	void Update () {
        Debug.Log(CityCenter.transform.position);
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
            }
            else
            {
                moveToLocation = false;
            }
        }
	}

    void FlyBy(GameObject currentPos, GameObject desiredPos)
    {
        //vector 3 heading = new Vector3 (50f,0,0);
        //CityCenter.transform.Translate(heading *speed* Time.deltaTime);
        

        //Debug.Log(heading);
    }
}
