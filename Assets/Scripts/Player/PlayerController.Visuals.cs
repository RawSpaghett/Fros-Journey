using UnityEngine;
//https://docs.unity3d.com/6000.3/Documentation/ScriptReference/Cursor.SetCursor.html

public partial class PlayerController : MonoBehaviour
{
    [Header("Cursor")]
    public Texture2D cursorTongueTexture;
    public Texture2D cursorIdleTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;


    public void TongueCursor(bool active)
    {
        if(active)
        {
            Cursor.SetCursor(cursorTongueTexture, hotSpot, cursorMode);
        }
        else
        {
            Cursor.SetCursor(cursorIdleTexture, hotSpot, cursorMode);
        }
    }

}
