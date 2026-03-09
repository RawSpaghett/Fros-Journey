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
    public float baseGravity;
    private float currentGravity;
    private Vector3 velocity;
    public float jumpMultiplier;
    public float minJumpStrength;
    public float maxJumpStrength;

    public CharacterController characterController;
    public MonoBehaviour tongueController;
    
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
        Gravity(jumpMultiplier);

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space))// Jump keys
        {
            Jumping();
        }
       
        if (Input.GetKeyDown(KeyCode.Mouse0)) // tongue
        {
            Tongue();
        }

        if (Input.GetKeyDown(KeyCode.Escape)) // Menu
        {}
        characterController.Move(speed * velocity * Time.deltaTime);
    }
    //================================================================
    private void Movement()
    {
        float x = Input.GetAxisRaw("Horizontal"); //listens for A and D (or arrow keys)
        velocity.x = x * speed;
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
    {}

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

        characterController.Move(velocity * Time.deltaTime); //move downwards

    }
    //================================================================
    private void Tongue()
    {}

}
