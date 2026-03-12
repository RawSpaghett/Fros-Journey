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
        //grab neccessary GetComponents
    }

    void update()
    {
        //UpdateLine() every frame to keep it consistent with movement
    }
    
    public void GrappleStart()
    {
        /*
        isGrappling
        GrappleCheck();
        Grapple logic
        GrappleEnd();
        */
    }

    private bool GrappleCheck()
    {
        /*
        isGrappling = true;
        Draw line to mouse pointer location
        Determine if target location is grappleable
        return true if it is a grappleable surface
        else false
        */
        return false;
    }

    private void GrappleEnd()
    {
        /*
        end the Grapple
        isGrappling = false;
        */
    }

    private void UpdateLine()
    {
        //update the visuals
    }




}
