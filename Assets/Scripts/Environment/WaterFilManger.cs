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

    public Animator animator;

    public GameObject[] objectsToShow;

    private float fillAmount = 0f;
    private bool isFilling = false;
    private bool hasTriggeredAnim = false;
    private bool hasShown = false;

    void Update()
    {
        if (isFilling)
        {
            fillAmount = Mathf.MoveTowards(fillAmount, 1f, fillSpeed * Time.deltaTime);

            water.position = Vector3.Lerp(
                minHeight.position,
                maxHeight.position,
                fillAmount
            );

            // ✅ When full
            if (fillAmount >= 1f)
            {
                if (!hasTriggeredAnim)
                {
                    hasTriggeredAnim = true;
                    animator.SetTrigger("LogFalling");
                }

                if (!hasShown)
                {
                    hasShown = true;

                    foreach (GameObject obj in objectsToShow)
                    {
                        obj.SetActive(true);
                    }
                }
            }
        }
    }

    public void StartFilling()
    {
        isFilling = true;
    }

    public void StopFilling()
    {
        isFilling = false;
    }
}
