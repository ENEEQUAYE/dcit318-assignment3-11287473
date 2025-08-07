namespace HealthcareSystem
{
    public class HealthSystemApp
    {
        private Repository<Patient> _patientRepo = new Repository<Patient>();
        private Repository<Prescription> _prescriptionRepo = new Repository<Prescription>();
        private Dictionary<int, List<Prescription>> _prescriptionMap = new Dictionary<int, List<Prescription>>();

        public void SeedData()
        {
            // Add patients
            _patientRepo.Add(new Patient(1, "John Doe", 30, "Male"));
            _patientRepo.Add(new Patient(2, "Jane Smith", 25, "Female"));
            
            // Add prescriptions
            _prescriptionRepo.Add(new Prescription(1, 1, "Ibuprofen", DateTime.Now.AddDays(-10)));
            _prescriptionRepo.Add(new Prescription(2, 1, "Amoxicillin", DateTime.Now.AddDays(-5)));
            _prescriptionRepo.Add(new Prescription(3, 2, "Paracetamol", DateTime.Now.AddDays(-3)));
            _prescriptionRepo.Add(new Prescription(4, 2, "Vitamin D", DateTime.Now.AddDays(-1)));
        }

        public void BuildPrescriptionMap()
        {
            var allPrescriptions = _prescriptionRepo.GetAll();
            _prescriptionMap = allPrescriptions
                .GroupBy(p => p.PatientId)
                .ToDictionary(g => g.Key, g => g.ToList());
        }

        public void PrintAllPatients()
        {
            foreach (var patient in _patientRepo.GetAll())
            {
                Console.WriteLine($"ID: {patient.Id}, Name: {patient.Name}, Age: {patient.Age}, Gender: {patient.Gender}");
            }
        }

        public void PrintPrescriptionsForPatient(int id)
        {
            if (_prescriptionMap.TryGetValue(id, out var prescriptions))
            {
                Console.WriteLine($"Prescriptions for patient ID {id}:");
                foreach (var p in prescriptions)
                {
                    Console.WriteLine($"- {p.MedicationName} (Issued: {p.DateIssued:yyyy-MM-dd})");
                }
            }
            else
            {
                Console.WriteLine($"No prescriptions found for patient ID {id}");
            }
        }
    }
}