using System.Collections;
using System.Collections.Generic;

public class Order 
{
    public int adults {get; set;}
    public int children {get;set;}
    public int oldPeople {get;set;}
    public int budget {get;set;}
    public float safety { get; set; }
    public float quality { get; set; }

    public List<SpecialRequest> requests;

    public Order( int adults, int children, int oldPeople, int budget, float safety, float quality){
        this.adults = adults;
        this.children = children;
        this.oldPeople = oldPeople;
        this.budget = budget;
        this.safety = safety;
        this.quality = quality;
        requests = new List<SpecialRequest>();
    }
}