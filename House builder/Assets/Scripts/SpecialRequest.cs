public class SpecialRequest : Request
{
    public SpecialRequest()
    {
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