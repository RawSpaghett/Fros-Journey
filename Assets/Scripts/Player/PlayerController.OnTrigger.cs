using UnityEngine;

public partial class PlayerController: MonoBehaviour
{
    
    private int waterContacts = 0;
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Water"))
        {
            waterContacts++;
            isSwimming = true;
            Swimming();
        }

        if (other.CompareTag("Egg"))
        {
            Destroy(other.gameObject);
            em.AddEgg();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Water"))
        {
            waterContacts--;

            if (waterContacts <= 0)
            {
                waterContacts = 0;
                isSwimming = false;
                Swimming();
            }
        }
    }
}
