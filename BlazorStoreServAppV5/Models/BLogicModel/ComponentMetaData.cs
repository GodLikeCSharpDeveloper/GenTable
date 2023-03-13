namespace BlazorStoreServAppV5.Models.BLogicModel;

public class ComponentMetaData
{
    public string? Name { get; set; }
    public Dictionary<string, object> Parameters { get; set; } = new();
}