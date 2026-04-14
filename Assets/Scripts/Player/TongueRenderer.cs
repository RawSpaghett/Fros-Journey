using UnityEngine;
using System.Collections;

//lots of the heavy lifting here is done by gemini, End of the semester has me beat

public class TongueRenderer : MonoBehaviour
{
    public SpriteRenderer tongueSprite;
    public PlayerController player;
    public float visualTongueSpeed = 10f;

    public bool isPulling = false;
    public bool isRendering = false;
    private Transform playerTransform;
    private Coroutine tongueExtendCo;


    void Awake()
    {
        tongueSprite= GetComponent<SpriteRenderer>();
        tongueSprite.enabled = false;
    }

    public void TongueIntiateVis(Vector3 target)
    {
        playerTransform = player.grapplePoint;
        tongueExtendCo = StartCoroutine(TongueExtendVis(target));
    }


    public IEnumerator TongueExtendVis(Vector3 target)
    {
        Debug.Log("Tongue Coroutine Started");
        tongueSprite.enabled = true;
        isRendering = true;
        Vector3 tongueTip = playerTransform.position;
        Transform spriteTrans = tongueSprite.transform;

        while(Vector3.Distance(tongueTip,target) > 0.1f) //while the distance between the tip and the target is greater than 0.1
        {
            tongueTip = Vector3.MoveTowards(tongueTip, target, visualTongueSpeed * Time.deltaTime); //slowly moves toward target

            UpdateSpriteTransform(tongueTip);
          
            yield return null;
        }
        if(player.hitSuccess)
        {
            isPulling = true;
        }
        else
        {
            while(Vector3.Distance(tongueTip, playerTransform.position) > 0.1f)
            {
                tongueTip = Vector3.MoveTowards(tongueTip, playerTransform.position, visualTongueSpeed * Time.deltaTime);
                UpdateSpriteTransform(tongueTip);
                yield return null;
            }
            DisableTongueVis();
        }

        
    }

    void Update()
    {
        if(isPulling)
        {
            UpdateSpriteTransform(player.grappleTarget);
        }
    }

    private void UpdateSpriteTransform(Vector3 endPoint) //gemini, i hate math
    {
        Transform spriteTrans = tongueSprite.transform;

        // Set base at player
        spriteTrans.position = playerTransform.position; 

        // Rotate to target
        Vector2 direction = endPoint - spriteTrans.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; 
        spriteTrans.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        float currentDist = Vector3.Distance(spriteTrans.position, endPoint);
        
        // Find out how wide your sprite image actually is before scaling
        float nativeSpriteWidth = tongueSprite.sprite.bounds.size.x;

        float parentScaleX = spriteTrans.parent != null ? spriteTrans.parent.lossyScale.x : 1f;
        
        // Divide the distance by the sprite's width to get the perfect scale multiplier!
        spriteTrans.localScale = new Vector3(currentDist / nativeSpriteWidth / parentScaleX, 1f, 1f);
    }


    public void DisableTongueVis()
    {
        isPulling = false;
        isRendering = false;
        tongueSprite.enabled = false;

        if (tongueExtendCo != null) //kill the coroutine
        {
            Debug.Log("<color=red>TongueVisuals Killed<color>");
            StopCoroutine(tongueExtendCo);
            tongueExtendCo = null;
        }
    }









}
