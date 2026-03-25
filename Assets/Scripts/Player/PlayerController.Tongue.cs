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

    
    private Vector3 GrappleTarget;
    private bool retract;
    
    void Start()
    {
        retract = false;//set to false
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
        retract = false;
        /*
            Stretch sprite
            Detect target GameObject and determine if its grappleable
            return true;
        */
        return false;
    }

    private void GrappleEnd()
    {
        retract = false; 
        WallStick(); //stick player to the wall
    }

    private void GrappleFail()
    {
        retract = true;
    }

    private void GrappleSucceed()
    {
        retract = true;
        //Move player towards the point in tandem with the tongue retraction
        //reverse tongue retraction to be mouth -> end instead of mouth <- end
    }

    public void WallStick()
    {
        //Freeze player position until either a timer expires, they fall, or they jump
    }


    /*
    private IEnumerator SpriteCreate() //gradually extends tongue so its not instant and waits to extend before anything else happens
    {}
    */

    private void SpriteRetraction() //Handles sprite retraction on grapple pull or grapple fail
    {
        if( retract == true )
        {
            //pull in tongue using Lerp between grapplepoint and tonguelocation
            return;
        }
        else
        {
            return;
        }
       
    }

}
