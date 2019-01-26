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
        for (int i = 0; i < order.requests.Count; i++)
        {
            Debug.Log(order.requests[i].type + " " + order.requests[i].roomAmount);
        }
        Debug.Log((int)(order.safety * 100));
        Debug.Log(order.quality.ToString("F1"));
        return order;
    }
    private float RandomValue(int min, int max)
    {
        int value = ((int)Random.Range(min, (max+1)*2))%((max+1));
        return value;
    }
}
