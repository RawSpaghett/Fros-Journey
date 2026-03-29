using UnityEngine;

[CreateAssetMenu(fileName = "Parallax", menuName = "Scriptable Objects/Parallax")]
public class ParallaxOBJ : ScriptableObject
{
    public Parallax Layer3; //farthest
    public Parallax Layer2;
    public Parallax Layer1;
    public Parallax Layer0; //closest
    public Parallax Foreground; //foreground
    public Vector3 WorldSpaceLocation;
}

[System.Serializable]
public class Parallax
{
    public Sprite Layer;
    public float ParallaxMultiplier;
}
