using InventorySystem.Models;
using InventorySystem.Interfaces;

namespace InventorySystem
{
    public class InventoryApp
    {
        private InventoryLogger<InventoryItem> _logger = new("inventory.json");

        public void SeedSampleData()
        {
            _logger.Add(new InventoryItem(1, "Laptop", 10, DateTime.Now.AddDays(-10)));
            _logger.Add(new InventoryItem(2, "Monitor", 15, DateTime.Now.AddDays(-5)));
            _logger.Add(new InventoryItem(3, "Keyboard", 25, DateTime.Now.AddDays(-3)));
        }

        public void SaveData() => _logger.SaveToFile();
        public void LoadData() => _logger.LoadFromFile();

        public void PrintAllItems()
        {
            foreach (var item in _logger.GetAll())
                Console.WriteLine($"ID: {item.Id}, Name: {item.Name}, Qty: {item.Quantity}, Added: {item.DateAdded:d}");
        }
    }
}