using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag_and_Drop : MonoBehaviour
{
    public GameObject Room_block;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void MousePosition()
    {
        float MouseX = Input.mousePosition.x;
        float MouseY = Input.mousePosition.y;
        // snaping block to grid
        Round_values(ref MouseX, ref MouseY);
    }
    private void Round_values(ref float x, ref float y)
    {
        if (x >= 0)
        {
            x = (int)x + 0.5f;
        }
        else
        {
            x = Mathf.Sign(x) * (Mathf.Abs((int)x) + 0.5f);
        }
        if (y >= 0)
        {
            y = (int)y + 0.5f;
        }
        else
        {
            y = Mathf.Sign(y) * ((int)Mathf.Abs(y) + 0.5f);
        }
    }
}
