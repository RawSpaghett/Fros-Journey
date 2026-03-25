using UnityEngine;

//ADD A SLIGHT CAMERA WIGGLE TO SHOW OFF PARALLAX BACKGROUNDS

//uses colliders to determine screen changes, getcomponent, allows for unique rooms sizes, NOT FEASIBLE FOR INFINITE GENERATION
public class WorldCamera : MonoBehaviour
{
    public Vector3 CurrentPosition; //define where it needs to go, need to add offset
    //public GameObject startStage;
    //public Vector3 startPosition = new Vector3(0f,0f,-10f);
    
    void Start()
    {
        /*
        startPosition.x = startStage.transform.position.x;
        startPosition.y = startStage.transform.position.y;
        transform.position = startPosition;
        */
        CurrentPosition = transform.position; //set it to current position
    }

    public void MoveTo(Vector3 TargetPosition) //to be called by collision script, snaps into place
    {
        transform.position = TargetPosition;
        CurrentPosition = TargetPosition;
    }
   
}
