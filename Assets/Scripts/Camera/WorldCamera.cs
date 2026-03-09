using UnityEngine;


//uses colliders to determine screen changes, getcomponent, allows for unique rooms sizes, NOT FEASIBLE FOR INFINITE GENERATION
public class WorldCamera : MonoBehaviour
{
    public Vector3 CurrentPosition; //define where it needs to go, need to add offset
    
    
    void Start()
    {
        CurrentPosition = transform.position; //set it to current position
    }

    public void MoveTo(Vector3 TargetPosition) //to be called by collision script, snaps into place
    {
        transform.position = TargetPosition;
        CurrentPosition = TargetPosition;
    }
   
}
