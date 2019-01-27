using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Request_Randomizer : MonoBehaviour
{

    public Order RandomizeRequest()
    {
        Order order = new Order(0,0,0,0,0,0);
        float specific_rooms_count = RandomValue(1, 20);
        for(int i=0;i<specific_rooms_count;i++)
        {
            float room_index = RandomValue(0, 5);
            RoomType type = (RoomType)room_index;
            bool added = false;
            foreach(SpecialRequest r in order.requests)
            {
                if(r.type==type)
                {
                    r.roomAmount++;
                    added = true;
                }
            }
            if(!added)
            {
                SpecialRequest sp = new SpecialRequest(type);
                order.requests.Add(sp);
            }
        }
        order.safety = Random.Range(0.3f, 0.75f);
        order.quality = Random.Range(1.25f, 2.75f);
        order.budget=Cash(order);
        return order;
    }
    private int Cash(Order order)
    {
        float cash = 0;
        for(int i=0;i<order.requests.Count;i++)
        {
            int base_cost=0;
            int base_security=0;
            RoomType type = order.requests[i].type;
            if(type==RoomType.Bathroom)
            {
                base_cost = (int)BaseCost.Bathroom;
                base_security = (int)BaseSecurity.Bathroom;
            }
            else if(type == RoomType.Bedroom)
            {
                base_cost = (int)BaseCost.Bedroom;
                base_security = (int)BaseSecurity.Bedroom;
            }
            else if (type == RoomType.Garage)
            {
                base_cost = (int)BaseCost.Garage;
                base_security = (int)BaseSecurity.Garage;
            }
            else if (type == RoomType.Kitchen)
            {
                base_cost = (int)BaseCost.Kitchen;
                base_security = (int)BaseSecurity.Kitchen;
            }
            else if (type == RoomType.LivingRoom)
            {
                base_cost = (int)BaseCost.LivingRoom;
                base_security = (int)BaseSecurity.LivingRoom;
            }
            else if (type == RoomType.Storage)
            {
                base_cost = (int)BaseCost.Storage;
                base_security = (int)BaseSecurity.Storage;
            }
            cash += (float)(base_cost * order.requests[i].roomAmount * order.quality + base_cost * ((float)((order.safety * 100) * order.requests[i].roomAmount) / (float)base_security));
        }
        cash = Mathf.Ceil(cash / 190) * 100;
        return (int)cash;
    }
    private float RandomValue(int min, int max)
    {
        int value = ((int)Random.Range(min, (max+1)*2))%((max+1));
        return value;
    }
}
