using UnityEngine;

public class CameraCollider : MonoBehaviour
{
    private Camera WorldCam;
    public Vector2 TargetPosition;

    void Start()
    {
      WorldCam = Camera.main; //grab the world cam as soon as this script is started
    }

   void OnTriggerEnter2D(Collision2D collider)
   {
      if(other.CompareTag("Player")) //make sure its the player colliding, Even if there are no enemies or anything
      {
         WorldCam.transform.position = TargetPosition;
      }
   }
}
