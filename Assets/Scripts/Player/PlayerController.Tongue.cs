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

    [Header("Grapple settings")]
    public float maxDistance = 10f;
    public float pullSpeed = 2f;

    [Header("Raycast settings")]
    public LayerMask grapplemask;


    private bool isGrappling;
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
            isGrappling = true;
            StartCoroutine(GrappleSucceed());
        }
        else //if returns false
        {
           return;
        }
    }

    private bool GrappleCheck()
    {
        Debug.Log("<color=green>GrappleCheck</color>");
        Plane zPlane = new Plane(Vector3.forward,Vector3.zero); //(flat against x and y, true origin)
        Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition); //draw a raycast to the mouse position from the screen to our plane
        float location;
        
        if (zPlane.Raycast(cameraRay, out location)) //determines if and where its been hit by the camera raycast
        {
            Vector3 mouseGamePosition = cameraRay.GetPoint(location);//gets the position of the raycast in the game space
            Vector3 direction = (mouseGamePosition - transform.position).normalized; //location of mouse minus location of player
            
            if (Physics.Raycast(transform.position, direction, out RaycastHit hit, maxDistance, grapplemask))//where it starts,where it points,stores where it hits,maximum distance, the grappleable layers
            {
            grappleTarget = hit.point; // Store where we hit
            Debug.Log("<color=green>GrappleCheckTrue</color>");
            return true;
            }

        }
        Debug.Log("<color=red>GrappleCheckFalse</color>");
        return false;
    }

    private void GrappleEnd()
    {
        isGrappling = false;
        //WallStick(); //stick player to the wall
    }

/* does not work, gemini made
    void TongueVisual()
    {
        Debug.Log("<color=green>TongueVisual</color>");
        // 1. Calculate the distance between player and target
        float distance = Vector3.Distance(transform.position, grappleTarget);

        // 2. Point the tongue at the target
        Vector3 dir = grappleTarget - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        grappleVisual.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        // 3. Stretch the tongue by changing its Size (not Scale!)
        // This works because we set the Draw Mode to Tiled
        grappleVisual.size = new Vector2(distance, grappleVisual.size.y);
    }
    */

    private IEnumerator GrappleSucceed()
    {
        Debug.Log("<color=green>GrappleSucceed</color>");
        while(Vector3.Distance(transform.position,grappleTarget) > 0.7) //while we are not there, 0.5 for buffer
        {
            Vector3 direction = (grappleTarget - transform.position).normalized; //normalized keeps it so our speed never changes
            velocity = direction * pullSpeed; //changes velocity to start grapple

            if ((characterController.collisionFlags & CollisionFlags.Sides) != 0) break; //checks character controllers default detection variables and stops if its detected
            yield return null;
        }
        GrappleEnd();
    }


    /*
    public void WallStick()
    {
        //Freeze player position until either a timer expires, they fall, or they jump
    }


    public IEnumerator WallStickTimer()
    {

    }
    */
}
