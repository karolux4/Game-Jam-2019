using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_information : MonoBehaviour
{
    private Order order;
    public Existing_Buildings buildings { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        Request_Randomizer randomizer = new Request_Randomizer();
        order = randomizer.RandomizeRequest();
        buildings = new Existing_Buildings();
    }

    // Update is called once per frame
    void Update()
    {
        for(int i=0;i<buildings.rooms.Count;i++)
        {
            Debug.Log(buildings.rooms[i]);
        }
    }
}
