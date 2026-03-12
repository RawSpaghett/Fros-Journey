using UnityEngine;


/*
    https://docs.unity3d.com/462/Documentation/Manual/class-CharacterController.html
*/

public class TongueController : MonoBehaviour
{
    [Header("Neccesary Components")]
    public GameObject grapplePoint;
    public LineRenderer grappleVisual;
    public CharacterController charController;
    public bool isGrappling {get; private set;}
    
    void Start()
    {
        //grab neccessary components
        grapplePoint = GetComponent<>();
        grappleVisual = GetComponent<>();
        charController = GetComponent<>();

        isGrappling = false;//set to false
    }

    void update()
    {
        //UpdateLine() every frame to keep it consistent with movement
    }
    
    public void GrappleStart()
    {
        if(GrappleCheck()) //if returns true
        {
            //pull player to target position and lock their position to the wall for a short amount of time where they can either fall or jump
        }
        else //if returns false
        {
            GrappleFail();
        }
    }

    private bool GrappleCheck()
    {
        isGrappling = true;
        /*
        Draw line to mouse pointer location
        Determine if target location is grappleable
        return true if it is a grappleable surface
        else false
        */
        return false;
    }

    private void GrappleEnd()
    {
        isGrappling = false; //mark not grappling
        GrappleFail(); // logic is about the same
    }

    private void GrappleFail()
    {
        /*
        retracts line without moving the character controller
        */
    }

    private void UpdateLine()
    {
        //update the visuals
    }

}
