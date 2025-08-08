using WarehouseSystem;
using WarehouseSystem.Models;

public class Program
{
    public static void Main()
    {
        var manager = new WarehouseManager();
        manager.SeedData();
        
        Console.WriteLine("Electronics:");
        manager.PrintAllItems(manager.Electronics);
        
        Console.WriteLine("\nGroceries:");
        manager.PrintAllItems(manager.Groceries);
        
        // Test error cases
        Console.WriteLine("\nTesting error scenarios:");
        try { manager.Electronics.AddItem(new ElectronicItem(1, "Duplicate", 1, "Test", 1)); }
        catch (Exception ex) { Console.WriteLine(ex.Message); }
        
        manager.RemoveItemById(manager.Groceries, 999);
        
        // Test invalid quantity by setting quantity directly to negative
        try { manager.Groceries.UpdateQuantity(3, -10); }
        catch (Exception ex) { Console.WriteLine($"Error: {ex.Message}"); }
    }
}