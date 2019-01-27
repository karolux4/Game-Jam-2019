using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level_information : MonoBehaviour
{
    private Order order;
    public int existing_budget { get; set; }
    public Existing_Buildings buildings { get; set; }
    public bool delete_mode { get; set; }
    public GameObject Money;
    public GameObject Time;
    public GameObject Requirements;
    public GameObject Safety;
    public GameObject Quality;
    private float total_time;
    // Start is called before the first frame update
    void Start()
    {
        Request_Randomizer randomizer = this.gameObject.AddComponent<Request_Randomizer>();
        order = randomizer.RandomizeRequest();
        existing_budget = order.budget;
        buildings = new Existing_Buildings();
        delete_mode=false;
        int amount = 0;
        string require = "";
        for(int i=0;i<order.requests.Count;i++)
        {
            amount += order.requests[i].roomAmount;
            require += order.requests[i].type.ToString() + "\t" + order.requests[i].roomAmount+"\t\t";
            if(i%2==1)
            {
                require += "\r\n";
            }
        }
        Time.GetComponent<GameUIControllerScript>().timeLeft = amount * 20;
        total_time = amount * 20;
        Requirements.GetComponent<Text>().text = require;
        Safety.GetComponent<Text>().text += " "+(order.safety*100).ToString("F0");
        Quality.GetComponent<Text>().text += " "+order.quality.ToString("F1");
    }

    // Update is called once per frame
    void Update()
    {
        Money.GetComponent<Text>().text = existing_budget.ToString();
        if(CheckIfLevelIsCompleted())
        {
            Debug.Log("You win");
        }
        //Debug.Log(existing_budget);
    }
    public void ChangeDeleteMode()
    {
        if(delete_mode)
        {
            delete_mode = false;
        }
        else
        {
            delete_mode = true;
        }
    }
    private bool CheckIfLevelIsCompleted()
    {
        float safety = 0, quality = 0;
        for (int i=0;i<buildings.room_amount;i++)
        {
            safety+=buildings.rooms[i].GetComponent<Room_info>().safety;
            quality+=buildings.rooms[i].GetComponent<Room_info>().quality;
        }
        float overall_safety=safety/(buildings.room_amount*100);
        float overall_quality=quality/buildings.room_amount;
        float safety_coef = (order.safety-overall_safety)/order.safety*0.3f;
        if(safety_coef<=0)
        {
           safety_coef=0.3f;
        }
        float quality_coef = (order.quality-overall_quality)/order.quality*0.3f;
        if(quality_coef<=0)
        {
           quality_coef=0.3f;
        }
        //Debug.Log(safety_coef);
        //Debug.Log(quality_coef);
        float room_coef = 0;
        for (int i = 0; i < order.requests.Count; i++)
        {
            RoomType type = order.requests[i].type;
            int amount = 0;
            for(int j=0;j<buildings.room_amount;j++)
            {
                if(buildings.rooms[j].GetComponent<Room_info>().type==type)
                 amount++;
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
        float time_coef= (total_time-(total_time-Time.GetComponent<GameUIControllerScript>().timeLeft))/total_time*0.2f;
        float overall_coef = safety_coef + quality_coef + room_coef + money_coef;// +time_coef;
        if (overall_coef >= 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
