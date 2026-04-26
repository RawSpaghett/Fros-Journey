using UnityEngine;

public class Lotus : MonoBehaviour
{
   

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            EggManager.instance.AddLotus();
            Destroy(gameObject);
        }
    }
}
