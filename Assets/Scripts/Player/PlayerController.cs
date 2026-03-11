using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //using Character Controller, Faked physics for more control
    //https://docs.unity3d.com/6000.3/Documentation/ScriptReference/CharacterController.html

    /*
        To-Do
        - Coyote Time
    */

    [Header("Movement Statistics")]
    public float speed;
    public float timeToMax; //acceleration
    public float friction; //friction

    public float baseGravity;
    public float gravityMultiplier; //change for underwater

    public float jumpMultiplier;
    public float minJumpStrength;
    public float maxJumpStrength;
    public float chargeTime;

    private float currentCharge;
    private float currentGravity;

    [SerializeField] 
    private Vector3 velocity;

    CharacterController characterController;
    MonoBehaviour tongueController;
    
    //================================================================
    void Awake() //grab neccessary GetComponents automatically
    {
        characterController = GetComponent<CharacterController>(); // grab the controller 
        tongueController = GetComponent<TongueController>(); // Grab the tongue script
    }

    void Update() //will take inputs using old unity input system, https://docs.unity3d.com/560/Documentation/ScriptReference/KeyCode.html
    {
        IsGrounded();
        Movement(); //inputs handled by GetAxis
        Gravity(gravityMultiplier);

        if (characterController.isGrounded)
        {
            Jumping();
        }
       
        if (Input.GetKeyDown(KeyCode.Mouse0)) // tongue
        {
            Tongue();
        }

        if (Input.GetKeyDown(KeyCode.Escape)) // Menu
        {}

        characterController.Move(velocity * Time.deltaTime);
    }

    //================================================================

    private void Movement()
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
        else
        {
            velocity.x = Mathf.Lerp(velocity.x,(x * speed),(Time.deltaTime * 0.25f)); //air strafing
        }
        velocity.z = 0f;
    }

    //================================================================

    private void IsGrounded()
    {
        if(characterController.isGrounded && velocity.y < 0)
        {
            velocity.y = -2;
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
    {}

}
