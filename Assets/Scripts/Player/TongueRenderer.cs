using UnityEngine;
using System.Collections;

public class TongueRenderer : MonoBehaviour
{
    public LineRenderer renderer;
    public PlayerController player;
    public float visualTongueSpeed = 10f;

    public bool isPulling = false;
    private Transform playerTransform;
    private Coroutine tongueExtendCo;

    void Awake()
    {
        renderer = GetComponent<LineRenderer>();
        renderer.positionCount = 0; //inactive, starts blank
    }

    public void TongueIntiateVis(Vector3 target)
    {
        playerTransform = player.grapplePoint;
        tongueExtendCo = StartCoroutine(TongueExtendVis(target));
    }


    public IEnumerator TongueExtendVis(Vector3 target)
    {
        Debug.Log("Tongue Coroutine Started");
        renderer.positionCount = 2;
        Vector3 tongueTip = playerTransform.position;


        while(Vector3.Distance(tongueTip,target) > 0.1f) //while the distance between the tip and the target is greater than 0.1
        {
            tongueTip = Vector3.MoveTowards(tongueTip, target, visualTongueSpeed * Time.deltaTime); //slowly moves toward target
            renderer.SetPosition(1, tongueTip); //actively sets position to the Vector3, following an invisible lead in a way
            renderer.SetPosition(0, playerTransform.position); //Unneccessary but just in case

            yield return null;
        }

        renderer.SetPosition(1, target);//snap to target
        isPulling = true;
    }

    void Update()
    {
        if(isPulling)
        {
            renderer.SetPosition(0,playerTransform.position); //point 1, dont need to change point 2 as it never changes
        }
    }

    public void DisableTongueVis()
    {
        isPulling = false;
        renderer.positionCount = 0;

        if (tongueExtendCo != null) //kill the coroutine
        {
            Debug.Log("<color=red>TongueVisuals Killed<color>");
            StopCoroutine(tongueExtendCo);
            tongueExtendCo = null;
        }
    }









}
