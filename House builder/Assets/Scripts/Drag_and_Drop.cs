using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag_and_Drop : MonoBehaviour
{
    public GameObject Room_block;
    public GameObject level_information;
    public float Room_length;
    public float Room_height;
    private Vector3 prev_position;
    private bool is_not_placed = true;
    private bool allowed_to_place = true;
    private bool trigerrered = false;
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
        if (prev_position != new Vector3(MouseX, MouseY, 0f)) //transition between two points
        {
            prev_position = new Vector3(MouseX, MouseY, 0f);
            Vector3 destination = new Vector3(MouseX, MouseY, 0f);
            StartCoroutine(MoveToPosition(Room_block.transform, destination, 0.1f));
        }
    }
    private void NormalizeMousePosition(ref float MouseX, ref float MouseY)
    {
        float X = 17.8f;
        float Y = 10f;
        MouseX = (MouseX / Screen.width) * X - (float)X / (float)2;
        MouseY = (MouseY / Screen.height) * Y - (float)Y / (float)2;
    }
    private void ObjectPlacement()
    {
        if (Input.GetMouseButtonDown(0) && allowed_to_place) // if left mouse button is pressed place an object
        {
            is_not_placed = false;
            Room_block.AddComponent<Destroy_Room>();
            Room_block.GetComponent<Destroy_Room>().Room_height = Room_height;
            Room_block.GetComponent<Destroy_Room>().Room_length = Room_length;
            Room_block.GetComponent<Destroy_Room>().level_information = level_information;
            level_information.GetComponent<Level_information>().buildings.room_amount++;
            level_information.GetComponent<Level_information>().buildings.rooms.Add(Room_block);
            // do build animations
            Cursor.visible = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        trigerrered = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        trigerrered = false;
    }
    private void CheckForHeight()
    {
        RaycastHit2D hit;
        int layer_mask = LayerMask.GetMask("Rooms", "Ground");
        Vector3 start = Room_block.transform.position - new Vector3(0f, (Room_height - 1) * 0.5f, 0f);
        hit = Physics2D.CircleCast(start,0.3f, Vector2.down, Mathf.Infinity, layer_mask);
        if ((hit.distance < 0.1f)&&(hit.collider!=null))
        {
            // Debug.Log(hit.distance);
            // Debug.Log("Not Height");
            if (!trigerrered)
            {
                allowed_to_place = true;
            }
            else
            {
                allowed_to_place = false;
            }
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
            x = (int)x + 0.5f * ((Room_length ) % 2);
        }
        else
        {
            x = Mathf.Sign(x) * (Mathf.Abs((int)x) + 0.5f * ((Room_length) % 2));
        }
        if (y >= 0)
        {
            y = (int)y;// + 0.5f*(Room_height)%2;
        }
        else
        {
            y = Mathf.Sign(y) * ((int)Mathf.Abs(y));
        }
    }
}
