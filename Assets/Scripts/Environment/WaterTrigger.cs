using UnityEngine;

public class WaterTrigger : MonoBehaviour
{
    public WaterFilManger waterManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            waterManager.StartFilling();
        }
    }
}
