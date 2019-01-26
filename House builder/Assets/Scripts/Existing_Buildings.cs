using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Existing_Buildings
{
    public int room_amount {get;set;}
    public List<GameObject> rooms { get; set; }
    
    public Existing_Buildings()
    {
        room_amount = 0;
        rooms = new List<GameObject>();
    }
}

