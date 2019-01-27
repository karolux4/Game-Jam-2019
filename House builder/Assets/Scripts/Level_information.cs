using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_information : MonoBehaviour
{
    private Order order;
    public int existing_budget { get; set; }
    public Existing_Buildings buildings { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        Request_Randomizer randomizer = new Request_Randomizer();
        order = randomizer.RandomizeRequest();
        existing_budget = order.budget;
        buildings = new Existing_Buildings();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private bool CheckIfLevelIsCompleted()
    {
        for(int i=0;i<buildings.room_amount;i++)
        {
            //float safety=0, quality=0; 
            //safety+=buildings.rooms[i].safety;
            //quality+=buildings.rooms[i].quality;
        }
        // overall_safety=safety/buildings.room_amount;
        // overall_quality=quality/buildings.room_amount;
        // safety_coef = (order.safety-overall_safety)/order.safety*0.3f;
        // if(safety_coef<=0)
        /*{
         *  safety_coef=0.3f;
        }*/
        // quality_coef = (order.quality-overall_quality)/order.quality*0.3f;
        // if(quality_coef<=0)
        /*{
         *  quality_coef=0.3f;
        }*/
        float room_coef = 0;
        for (int i = 0; i < order.requests.Count; i++)
        {
            RoomType type = order.requests[i].type;
            int amount = 0;
            for(int j=0;j<buildings.room_amount;j++)
            {
                /*if(buildings.rooms[j].type==type)
                 * amount++;
                 */
            }
            float room_proportion = (order.requests[i].roomAmount - amount) / order.requests[i].roomAmount*(-0.1f);
            if(room_proportion>=0)
            {
                room_proportion = 0.1f;
            }
            room_coef += room_proportion;
        }
        room_coef += 0.1f * (6 - order.requests.Count);
        float money_coef = (existing_budget / order.budget) * 0.1f;
        // float time_coef= (time_limit-time_spent)/time_limit*0.2f;
        // overall_coef = safety_coef+quality_coef+room_coef+money_coef+time_coef;
        // if(overall_coef>=1)
        //{ return true;}
        return false;
    }
}
