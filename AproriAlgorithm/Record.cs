#nullable disable
public class Record
{
    public string[] items;

    public void FillList(string[] items)
    {
        this.items = new string[items.Length];
        this.items = items;        
    }
}