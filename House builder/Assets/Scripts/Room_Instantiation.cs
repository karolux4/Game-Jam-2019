using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room_Instantiation : MonoBehaviour
{
    public GameObject Room_prefab;
    public GameObject Level_information;
    // Start is called before the first frame update
    public void Instantiate()
    {
        GameObject room = Instantiate(Room_prefab);
        //Rigidbody2D rd = room.AddComponent<Rigidbody2D>();
        //rd.bodyType = RigidbodyType2D.Kinematic;
        //BoxCollider2D col = room.AddComponent<BoxCollider2D>();
        //col.isTrigger = true;
        //needs to ajust BoxCollider according to length and height
        //col.offset = new Vector2(0f,height/2);
        // col.size = new Vector2(length-0.03f, height-0.03f);
        //Drag_and_Drop DaD = room.AddComponent<Drag_and_Drop>();
        //DaD.Room_block = this.gameObject;
       // DaD.Room_height = height;
       // DaD.Room_length = length;
        room.GetComponent<Drag_and_Drop>().level_information = Level_information;
    }
}
