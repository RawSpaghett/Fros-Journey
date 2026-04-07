using UnityEngine;
using UnityEngine.UI;

public class EggManager : MonoBehaviour
{
    public int eggCount;
    public Text eggText;
    public GameObject finish;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        eggText.text = ": " + eggCount.ToString();
    }
}
