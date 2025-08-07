using InventorySystem;

public class Program
{
    public static void Main()
    {
        var app = new InventoryApp();
        app.SeedSampleData();
        app.SaveData();
        
        // Simulate restart
        var newApp = new InventoryApp();
        newApp.LoadData();
        newApp.PrintAllItems();
    }
}