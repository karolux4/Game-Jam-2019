using System.Collections;
using System.Collections.Generic;

public class Room 
{
    public string name { get; set; }
    public RoomType type {get; set;}
    public int price{get;set;}
    public float quality{get;set;}
    public float safety { get; set; }

    public Room( string name, RoomType type, int price, float quality, float safety){
        this.name = name;
        this.type = type;
        this.price = price;
        this.quality = quality;
    }
}

public enum RoomType
    {
    Kitchen,
    LivingRoom,
    Bedroom,
    Garage,
    Bathroom,
    Storage
    }
