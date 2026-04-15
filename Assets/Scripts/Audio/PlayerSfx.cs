using UnityEngine;

public class Playersfx : MonoBehaviour
{
    [SerializeField] private float stepInterval = 0.5f;
    private float stepTimer;

    void Update()
    {
        HandleSpringJump();
        HandleHopSteps();
    }

    void HandleSpringJump()
    {
        if (Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.W))
        {
            if (!Input.GetKey(KeyCode.Space) && !Input.GetKey(KeyCode.W))
            {
                AudioManager.Instance.PlaySFX(SFXType.SpringJump);
            }
        }
    }

    void HandleHopSteps()
    {
        bool isMovingSideways = Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D);

        if (isMovingSideways)
        {
            stepTimer -= Time.deltaTime;

            if (stepTimer <= 0f)
            {
                AudioManager.Instance.PlaySFX(SFXType.HopSteps, 0.4f);
                stepTimer = stepInterval;
            }
        }
        else
        {
            stepTimer = stepInterval; 
        }
    }
}