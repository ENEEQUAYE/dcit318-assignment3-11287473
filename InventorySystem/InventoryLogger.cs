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
            try
            {
                using var writer = new StreamWriter(_filePath);
                string json = JsonSerializer.Serialize(_log, new JsonSerializerOptions { WriteIndented = true });
                writer.Write(json);
                Console.WriteLine($"Data saved successfully to {_filePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving data: {ex.Message}");
            }
        }

        public void LoadFromFile()
        {
            try
            {
                if (File.Exists(_filePath))
                {
                    using var reader = new StreamReader(_filePath);
                    string json = reader.ReadToEnd();
                    _log = JsonSerializer.Deserialize<List<T>>(json) ?? new();
                    Console.WriteLine($"Data loaded successfully from {_filePath}");
                }
                else
                {
                    Console.WriteLine($"File {_filePath} not found. Starting with empty inventory.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading data: {ex.Message}");
                _log = new(); // Initialize empty list on error
            }
        }
    }
}