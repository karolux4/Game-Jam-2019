using System.Collections;
using System.Collections.Generic;

public class Room 
{
    public string name { get; set; }
    public RoomType type {get; set;}
    public int price{get;set;}
    public float quality{get;set;}
    public float safety { get; set; }
    public float length { get; set; }
    public float height { get; set; }

    public Room( string name, RoomType type, int price, float quality, float safety, float length, float height){
        this.name = name;
        this.type = type;
        this.price = price;
        this.quality = quality;
        this.length = length;
        this.height = height;
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
public enum BaseCost
{
    Kitchen=1200,
    LivingRoom=1500,
    Bedroom=1400,
    Garage=800,
    Bathroom=1000,
    Storage=500
}
public enum BaseSecurity
{
    Kitchen = 25,
    LivingRoom = 30,
    Bedroom = 30,
    Garage = 20,
    Bathroom = 25,
    Storage = 20
}
