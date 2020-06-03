public class PassModel
{
    public string Id { get; private set; }
    public double Height { get; private set; }

    public PassModel(string id, double height)
    {
        Id = id;
        Height = height;
    }

}