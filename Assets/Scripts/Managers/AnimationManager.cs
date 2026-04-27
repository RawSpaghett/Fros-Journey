using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    public Animator animA;
    public Animator animB;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PlayBoth();
        }
    }

    public void PlayBoth()
    {
        animA.SetTrigger("Start");
        animB.SetTrigger("Start");
    }
}
