﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_Room : MonoBehaviour
{
    //public bool DeleteIsOn { get; set; }
    public GameObject level_information;
    public GameObject DestroyedRoom;
    public float Room_length;
    public float Room_height;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //DeleteIsOn = level_information.GetComponent<Level_information>().delete_mode;
    }
    private void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(0)&&(level_information.GetComponent<Level_information>().delete_mode))
        {
            RaycastHit2D hit;
            Vector3 start = this.gameObject.transform.position+new Vector3(0f,Room_height,0f);
            int layer_mask = LayerMask.GetMask("Rooms");
            hit = Physics2D.Raycast(start, Vector2.up, Mathf.Infinity, layer_mask);
            if (hit.collider != null)
            {
                if (hit.collider.gameObject.layer!=10)
                {
                    level_information.GetComponent<Level_information>().buildings.room_amount--;
                    level_information.GetComponent<Level_information>().buildings.rooms.Remove(this.gameObject);
                    level_information.GetComponent<Level_information>().existing_budget += this.gameObject.GetComponent<Room_info>().price;
                    Destroy(this.gameObject);
                    Instantiate(DestroyedRoom);
                }
            }
            else
            {
                level_information.GetComponent<Level_information>().buildings.room_amount--;
                level_information.GetComponent<Level_information>().buildings.rooms.Remove(this.gameObject);
                level_information.GetComponent<Level_information>().existing_budget += this.gameObject.GetComponent<Room_info>().price;
                Destroy(this.gameObject);
                Instantiate(DestroyedRoom);
            }
        }
    }
}
