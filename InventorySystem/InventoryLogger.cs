using System.Text.Json;
using InventorySystem.Interfaces;

namespace InventorySystem
{
    public class InventoryLogger<T> where T : IInventoryEntity
    {
        private List<T> _log = new();
        private string _filePath;

        public InventoryLogger(string filePath) => _filePath = filePath;

        public void Add(T item) => _log.Add(item);
        public List<T> GetAll() => _log;

        public void SaveToFile()
        {
            string json = JsonSerializer.Serialize(_log, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_filePath, json);
        }

        public void LoadFromFile()
        {
            if (File.Exists(_filePath))
                _log = JsonSerializer.Deserialize<List<T>>(File.ReadAllText(_filePath)) ?? new();
        }
    }
}