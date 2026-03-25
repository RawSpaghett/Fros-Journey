using UnityEngine;

public class parallaxEffect : MonoBehaviour
{
    public float startPos;

    [SerializeField] private Camera cam; //grab main camera
    [SerializeField] private float parallaxMultiplier; //amount the background moves with player


    void Start()
    {
        cam = Camera.main; //grab main cam
        startPos = transform.position.x; //grab sprite position
        //cameraTemp = cam.transform.position;
    }

    void Update() //grabs the difference between the orioginal position and the new position essentially making microadjustments
    {
    }
}
