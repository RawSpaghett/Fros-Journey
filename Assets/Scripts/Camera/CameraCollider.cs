using UnityEngine;


public class CameraCollider : MonoBehaviour
{
    private Camera WorldCam;
    public Vector2 TargetPosition;
    public GameObject nextStage;
    public bool automatic;


    void Start()
    {
     WorldCam = Camera.main;
    }

   void OnTriggerEnter(Collider collider)
   {
      if(collider.CompareTag("Player")) //make sure its the player colliding, Even if there are no enemies or anything
      {
         Vector3 newPosition = WorldCam.transform.position; //used to keep z value
         if(!automatic)
         {
            newPosition.x = TargetPosition.x;
            newPosition.y = TargetPosition.y;
         }
         else
         {
            newPosition.x = nextStage.transform.position.x;
            newPosition.y = nextStage.transform.position.y + 5f;
         }
         WorldCam.transform.position = newPosition;
      }
   }
}
