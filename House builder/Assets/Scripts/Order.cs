using System.Collections;
using System.Collections.Generic;

public class Order 
{
    public int adults {get; set;}
    public int children {get;set;}
    public int oldPeople {get;set;}
    public int budget {get;set;}

    public SpecialRequest[] requests;

    public Order( int adults, int children, int oldPeople, int budget){
        this.adults = adults;
        this.children = children;
        this.oldPeople = oldPeople;
        this.budget = budget;
    }
}