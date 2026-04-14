using UnityEngine;

public class WaterFilManger : MonoBehaviour
{
    
    [Header("Water Object")]
    public Transform water;

    [Header("Fill Bounds")]
    public Transform minHeight;
    public Transform maxHeight;

    [Header("Settings")]
    public float fillSpeed = 1f;

    private float fillAmount = 0f;
    private bool isFilling = false;

    void Update()
    {
        if (isFilling)
        {
            fillAmount = Mathf.MoveTowards(fillAmount, 1f, fillSpeed * Time.deltaTime);
            fillAmount = Mathf.Clamp01(fillAmount);

            water.position = Vector3.Lerp(
                minHeight.position,
                maxHeight.position,
                fillAmount
            );
        }
    }

    

    //called by scene actions
    public void StartFilling()
    {
        isFilling = true;
    }

    public void StopFilling()
    {
        isFilling = false;
    }
}
