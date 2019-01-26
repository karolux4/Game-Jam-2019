using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag_and_Drop : MonoBehaviour
{
    public GameObject Room_block;
    private Vector3 prev_position;
    private bool is_not_placed = true;
    private bool allowed_to_place = true;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false; //needs discussing
        prev_position = Room_block.GetComponent<Transform>().position;
    }

    // Update is called once per frame
    void Update()
    {
        CheckForHeight();
        ObjectColor(); //needs upgrading
        if (is_not_placed)
        {
            BlockPosition(); // object snaping to grid
            ObjectPlacement();
        }
    }

    public void BlockPosition()
    {
        float MouseX = Input.mousePosition.x;
        float MouseY = Input.mousePosition.y;
        NormalizeMousePosition(ref MouseX, ref MouseY);
        // snaping block to grid
        RoundValues(ref MouseX, ref MouseY); // rounding x and y values to nearest 0.5;
        if (prev_position != new Vector3(MouseX, MouseY, 0)) //transition between two points
        {
            Vector3 destination = new Vector3(MouseX, MouseY, 0);
            StartCoroutine(MoveToPosition(Room_block.transform, destination, 0.1f));
        }
    }
    private void NormalizeMousePosition(ref float MouseX, ref float MouseY)
    {
        float X = 20.4f;
        float Y = 11.4f;
        MouseX = (MouseX / Screen.width) * X - (float)X / (float)2;
        MouseY = (MouseY / Screen.height) * Y - (float)Y / (float)2;
    }
    private void ObjectColor()
    {
        if (allowed_to_place)
        {
            Room_block.GetComponent<Renderer>().material.color = new Color(0, 1, 0, 1);
        }
        else
        {
            Room_block.GetComponent<Renderer>().material.color = new Color(1, 0, 0, 1);
        }
    }
    private void ObjectPlacement()
    {
        if (Input.GetMouseButtonDown(0) && allowed_to_place) // if left mouse button is pressed place an object
        {
            is_not_placed = false;

            // do build animations
            Cursor.visible = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        allowed_to_place = false;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        allowed_to_place = true;
    }
    private void CheckForHeight()
    {
        RaycastHit2D hit;
        int layer_mask = LayerMask.GetMask("Rooms", "Ground");
        hit = Physics2D.Raycast(Room_block.transform.position, Vector2.down, Mathf.Infinity, layer_mask);
        if ((hit.distance < 1) && (hit.distance != 0))
        {
            allowed_to_place = true;
        }
        else
        {
            allowed_to_place = false;
        }
    }
    private IEnumerator MoveToPosition(Transform transform, Vector3 destination, float timeToMove)
    {
        Vector3 currentPos = transform.position;
        float t = 0f;
        while (t < 1)
        {
            t += Time.deltaTime / timeToMove;
            Room_block.transform.position = Vector3.Lerp(currentPos, destination, t);
            yield return null;
        }
    }
    private void RoundValues(ref float x, ref float y)
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
