using UnityEngine;
using System.Collections;


/*
    https://docs.unity3d.com/462/Documentation/Manual/class-CharacterController.html
*/

public partial class PlayerController : MonoBehaviour
{
    [Header("Neccesary Tongue Components")]
    public Transform grapplePoint;

    [Header("Grapple settings")]
    public float maxDistance = 10f;
    public float pullSpeed = 2f;

    [Header("Raycast settings")]
    public LayerMask grapplemask;

    
    public bool isSticking;
    private bool isGrappling;
    public Vector3 grappleTarget;
    private Vector3 mousePosition;
    private Coroutine currentStick;

    
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
        Vector3 missTarget = transform.position;

        if (zPlane.Raycast(cameraRay, out location)) //determines if and where its been hit by the camera raycast
        {
            Vector3 mouseGamePosition = cameraRay.GetPoint(location);//gets the position of the raycast in the game space
            Vector3 direction = (mouseGamePosition - transform.position).normalized; //location of mouse minus location of player
            missTarget = transform.position + (direction * maxDistance);

            if (Physics.Raycast(transform.position, direction, out RaycastHit hit, maxDistance, grapplemask))//where it starts,where it points,stores where it hits,maximum distance, the grappleable layers
            {
                grappleTarget = hit.point; // Store where we hit
                
                Debug.Log("<color=green>GrappleCheckTrue</color>");
                tongueRenderer.TongueIntiateVis(grappleTarget);
                return true;
            }

        }
        grappleTarget = missTarget;
        Debug.Log("<color=red>GrappleCheckFalse</color>");
        tongueRenderer.TongueIntiateVis(grappleTarget);
        return false;
    }

    private void GrappleEnd()
    {
        isGrappling = false;
        tongueRenderer.DisableTongueVis();
        WallStick();
    }

    private IEnumerator GrappleSucceed()
    {
        KillWallStick();
        Debug.Log("<color=green>GrappleSucceed</color>");
        yield return new WaitUntil(() => tongueRenderer.isPulling); //lamba expression
        while(Vector3.Distance(transform.position,grappleTarget) > 0.7) //while we are not there, 0.5 for buffer
        {
            Vector3 direction = (grappleTarget - transform.position).normalized; //normalized keeps it so our speed never changes
            velocity = direction * pullSpeed; //changes velocity to start grapple

            if ((characterController.collisionFlags & CollisionFlags.Sides) != 0) break; //checks character controllers default detection variables and stops if its detected
            yield return null;
        }
        GrappleEnd();
    }

    public void WallStick()
    {
        if(isSticking) return; //if already sticking

        currentStick= StartCoroutine(WallStickTimer()); //start the stick
    }


    public IEnumerator WallStickTimer()
    {
        Debug.Log("<color=orange>StickStart</color>");
        isSticking = true;

        currentGravity = 0f;

        velocity = Vector2.zero;

        yield return new WaitForSeconds(3f);

        Debug.Log("<color=orange>StickEnd</color>");
        currentGravity = baseGravity;
        isSticking = false;
    }

    public void KillWallStick()
    {
        if (currentStick != null)
        {
            Debug.Log("<color=red>WallStick Killed<color>");
            StopCoroutine(currentStick);
            currentStick = null;
        }
        isSticking = false;
        currentGravity = baseGravity;
    }
    
}
