using UnityEngine;

public class Flowingwater : MonoBehaviour
{
    public Vector2 direction = new Vector2(0, -1);
    public float speed = 0.5f;

    private Material mat;

    void Awake()
    {
        mat = GetComponent<Renderer>().material;
    }

    void Update()
    {
        if (mat == null) return;

        mat.mainTextureOffset += direction.normalized * speed * Time.deltaTime;
    }
}
