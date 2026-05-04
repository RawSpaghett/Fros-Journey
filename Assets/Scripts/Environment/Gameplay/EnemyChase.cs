using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    public Transform player;
    public float speed = 3f;
    public float sightRange = 6f;

    private Vector3 startPosition;
    private bool isChasing = false;

    public Animator anim;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
        startPosition = transform.position;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (player == null) return;

        float distance = Vector2.Distance(transform.position, player.position);
        

        isChasing = distance < sightRange;

        anim.SetBool("isChasing", isChasing);

        if (isChasing)
        {
            ChasePlayer();
        }
        else
        {
            ReturnToIdle();
        }
    }

    void ChasePlayer()
    {
        Vector2 direction = (player.position - transform.position).normalized;
        transform.position += (Vector3)direction * speed * Time.deltaTime;
    }

    void ReturnToIdle()
    {
        Vector2 direction = (startPosition - transform.position).normalized;

        if (Vector2.Distance(transform.position, startPosition) > 0.1f)
        {
            transform.position += (Vector3)direction * speed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().Respawn();
        }
    }
}
