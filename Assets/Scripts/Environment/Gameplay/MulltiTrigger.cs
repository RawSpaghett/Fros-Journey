using UnityEngine;

public class MulltiTrigger : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            RaycastHit2D[] hits = Physics2D.RaycastAll(pos, Vector2.zero);

            foreach (RaycastHit2D hit in hits)
            {
                hit.collider.GetComponent<Animator>()?.SetTrigger("PlayAnim");
            }
        }
    }
}
