using UnityEngine;


//uses colliders to determine screen changes, getcomponent, allows for unique rooms sizes, NOT FEASIBLE FOR INFINITE GENERATION
public class WorldCamera : MonoBehaviour
{
    public Vector2 CurrentPosition; //define where it needs to go
    
    void Start()
    {
        CurrentPosition = transform.position; //set it to current position
    }

    public void MoveTo(Vector2 TargetPosition) //to be called by collision script, snaps into place
    {
        transform.position = TargetPosition;
        CurrentPosition = TargetPosition;
    }
   
}
