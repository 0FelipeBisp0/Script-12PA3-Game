using UnityEngine;

public class ToggleCanvasOnKey : MonoBehaviour
{
    public Canvas canvas;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            if (canvas != null)
            {
                canvas.enabled = !canvas.enabled;
            }
        }
    }

    
}
