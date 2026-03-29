using UnityEngine;
using System.Collections;


/*
    https://docs.unity3d.com/462/Documentation/Manual/class-CharacterController.html
*/

public partial class PlayerController : MonoBehaviour
{
    [Header("Neccesary Tongue Components")]
    public Transform grapplePoint;
    public SpriteRenderer grappleVisual;

    [Header("Raycast settings")]
    public LayerMask grapplemask;


    
    private Vector3 grappleTarget;
    private Vector3 mousePosition;

    
    void Start()
    {
        Cursor.SetCursor(cursorIdleTexture, hotSpot, cursorMode);
    }

    public void GrappleStart()
    {
        if(GrappleCheck()) //if returns true
        {
            /*
            pull player to target position and lock their position to the wall for a short amount of time where they can either fall or jump
            */
        }
        else //if returns false
        {
            GrappleFail();
        }
    }

    private bool GrappleCheck()
    {
        Plane zPlane = new Plane(Vector3.forward,Vector3.zero); //(flat against x and y, true origin)
        Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition); //draw a raycast to the mouse position from the screen to our plane
        float location;
        
        if (zPlane.Raycast(cameraRay,  out location)) //determines if and where its been hit by the camera raycast
        {
            Vector3 mouseGamePosition = cameraRay.GetPoint(location);//gets the position of the raycast in the game space

        }
        return false;
    }

    private void GrappleEnd()
    {
        WallStick(); //stick player to the wall
    }

    private void GrappleFail()
    {
       
    }

    private void GrappleSucceed()
    {
        //Move player towards the point in tandem with the tongue retraction
        //reverse tongue retraction to be mouth -> end instead of mouth <- end
    }

    public void WallStick()
    {
        //Freeze player position until either a timer expires, they fall, or they jump
    }


    /*
    private IEnumerator SpriteCreate() //gradually extends tongue so its not instant and waits to extend before anything else happens
    {

    }
    */
    

    private void SpriteRetraction() //Handles sprite retraction on grapple pull or grapple fail
    {

    }

}
