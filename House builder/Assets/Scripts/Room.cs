using System.Collections;
using System.Collections.Generic;

public class Room 
{
    public RoomType type {get; set;}
    public int price{get;set;}
    public int quality{get;set;}

    public Room( RoomType type, int price, int quality){
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
    Storage,
    OutdoorsRoom
    }
