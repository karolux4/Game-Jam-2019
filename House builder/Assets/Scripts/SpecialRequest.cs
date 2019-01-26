public class SpecialRequest : Request
{
    public SpecialRequest()
    {
        
    }
    public SpecialRequest(RoomType type)
    {
        this.type = type;
        roomAmount = 1;
    }

    public override bool CheckValidity(string[] data)
    {
        return true;
        //TODO implement
    }

    public override string Description()
    {
        return "true";
        //TODO implement
    }


    public int roomAmount{get;set;}
    public RoomType type{get;set;}
}