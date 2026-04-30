using UnityEngine;

public class ShowObjects : MonoBehaviour
{
    public GameObject[] objectsToShow;

    public void ShowNow()
    {
        foreach (GameObject obj in objectsToShow)
        {
            obj.SetActive(true);
        }
    }
}
