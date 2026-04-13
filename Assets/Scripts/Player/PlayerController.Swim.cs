using UnityEngine;

public partial class PlayerController: MonoBehaviour
{
   [Header("Swimming")]
   public bool isSwimming = false;
   public float swimSpeed = 5f;
   public float swimJumpMin = 1f;
   public float swimJumpMax = 2f;
   public float swimGravity = 0.65f;

   public void Swimming() //handles both enter and exit
   {
        if(isSwimming)
            {
                gravityMultiplier = swimGravity;
                speed = swimSpeed;
                velocity.x = velocity.x * 0.5f;
            }
            else
            {
                gravityMultiplier = 1f;
                speed = baseSpeed;
            }
   }

}
