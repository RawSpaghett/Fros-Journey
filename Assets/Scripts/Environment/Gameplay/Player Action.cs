using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void OnMouseDown()
    {
        anim.SetTrigger("PlayerAction");
    }
}
