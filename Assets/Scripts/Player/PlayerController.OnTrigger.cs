using UnityEngine;

public partial class PlayerController: MonoBehaviour
{
     private void OnTriggerEnter2D(Collider2D other) //when entering the water
    {
        if (other.CompareTag("Water"))
        {
            Debug.Log("<Color=yellow> swimmytag </Color>");
            isSwimming = true;
            Swimming();
            Debug.Log("<Color=blue> WATER </color>");
        }

        if (other.gameObject.CompareTag("Egg")) //kaitlyn
        {
            Destroy(other.gameObject);
            em.eggCount++;
        }
        //waterCheck water gameobject if true isSwimming
        //private void isSwimming
        //if isSwimming gravity -2ish player should freely move x,y
        //still allow player to jump but at a static rate
    }

     private void OnTriggerExit2D(Collider2D other) //when leaving the water
    {
        if (other.CompareTag("Water"))
        {
            isSwimming = false;
            Swimming();
            Debug.Log("<color=blue>LEAVING WATER</color>");
        }
    }
}
