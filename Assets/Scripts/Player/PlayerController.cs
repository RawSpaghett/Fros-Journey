using UnityEngine;

public partial class PlayerController : MonoBehaviour
{
    //using Character Controller, Faked physics for more control
    //https://docs.unity3d.com/6000.3/Documentation/ScriptReference/CharacterController.html

    /*
        To-Do
        - Coyote Time
    */

    public CharacterController characterController;

    [Header("Ground Movement")]
    public float speed;
    public float timeToMax; //acceleration
    public float friction; //friction

    [Header("Gravity")]
    public float baseGravity = -9.81f;//earth gravity
    public float gravityMultiplier; //change for underwater

    [Header("Jumping")]
    public float jumpMultiplier;
    public float airControl;
    public float minJumpStrength;
    public float maxJumpStrength;
    public float chargeTime;

    private float currentCharge;
    private float currentGravity;
    private bool isStunned = false;

    [Header("Current Velocity (For Debug)")]
    [SerializeField] 
    private Vector3 velocity;


    //================================================================
    void Awake() //grab neccessary GetComponents automatically
    {
    }

    void Update() //will take inputs using old unity input system, https://docs.unity3d.com/560/Documentation/ScriptReference/KeyCode.html
    {
        IsGrounded();

        Movement(); //inputs handled by GetAxis

        if(!isSticking)
        {
            Gravity(gravityMultiplier);
        }

        if (characterController.isGrounded || isSticking)
        {
            Jumping();
            Tongue();
        }
       

        if (Input.GetKeyDown(KeyCode.Escape)) // Menu
        {}

        characterController.Move(velocity * Time.deltaTime);


    }

    //================================================================

    private void Movement()
    {
        if(!isGrappling && !isSticking) //false
        {
        float x = Input.GetAxisRaw("Horizontal"); //listens for A and D (or arrow keys)
        if(characterController.isGrounded)
        {
            if(x != 0)
            {
                velocity.x = (Mathf.Lerp(velocity.x,(speed * x),(timeToMax * Time.deltaTime))); //on the ground 
            }
            if(x == 0) //if input is equal to zero
            {
                velocity.x = (Mathf.Lerp(velocity.x,0f,(friction * Time.deltaTime)));
            }
        }
        else if (!isStunned)
        {
            velocity.x = Mathf.Lerp(velocity.x,(x * speed),(Time.deltaTime * airControl)); //air strafing
        }
        velocity.z = 0f;
        }
    }

    //================================================================

    private void IsGrounded()
    {
        if(characterController.isGrounded && velocity.y < 0)
        {
            velocity.y = -2;
            isStunned = false;
        }

        if((characterController.collisionFlags & CollisionFlags.Above) != 0 && !isSticking && !isGrappling) //head hit check
        {
            isStunned = true;
            Debug.Log("<color=blue> Hit Head! <color>");
            velocity.y = 0;
            velocity.x = 0;
        }
    }

    //================================================================

    private void Jumping() //chargeable, Charge icon? ( Zelda )
    {

        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W)) //if held down
        {
            currentCharge += Time.deltaTime;
            float t = Mathf.Clamp01(currentCharge / chargeTime);//keeps it between 0 and 1 to prevent overcharge, t is the percent between the lerp
            jumpMultiplier= Mathf.Lerp(minJumpStrength,maxJumpStrength,t); // jumpMultiplier becomes equal to the length of the time it was held down 
        }
        
        else if (Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.W)) //when its let go
        {
            KillWallStick();
            velocity.y = jumpMultiplier;
        }
        else
        {
        //reset variables
        currentCharge = 0f;
        jumpMultiplier = minJumpStrength;
        }
    }

    //================================================================

    private void Gravity(float gravityMultiplier) //seperate, to handle swimming later and speedfall
    {
        if(Input.GetKey(KeyCode.S) && !characterController.isGrounded) //if speedfalling
        {
            currentGravity = baseGravity * gravityMultiplier;
        }

        else 
        {
            currentGravity = baseGravity;
        }

        velocity.y += currentGravity * Time.deltaTime; //calculate vertical velocity
    }
    //================================================================
    private void Tongue()
    {

        if (Input.GetKey(KeyCode.Mouse0) && (characterController.isGrounded || isSticking)) // held down
        {
            Debug.Log("<color=green>TongueInput</color>");
            TongueCursor(true);
            velocity.x = 0;
        }

        if(Input.GetKeyUp(KeyCode.Mouse0)) // let go
        {
            GrappleStart();
            TongueCursor(false); //off
        }
    }

}
