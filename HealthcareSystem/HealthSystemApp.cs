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
            _patientRepo.Add(new Patient(1, "Emmanuel Neequaye", 30, "Male"));
            _patientRepo.Add(new Patient(2, "Diana Koshie", 25, "Female"));
            _patientRepo.Add(new Patient(3, "Gabriel Grant", 45, "Male"));
            
            // Add prescriptions
            _prescriptionRepo.Add(new Prescription(1, 1, "Ibuprofen", DateTime.Now.AddDays(-10)));
            _prescriptionRepo.Add(new Prescription(2, 1, "Amoxicillin", DateTime.Now.AddDays(-5)));
            _prescriptionRepo.Add(new Prescription(3, 2, "Paracetamol", DateTime.Now.AddDays(-3)));
            _prescriptionRepo.Add(new Prescription(4, 2, "Vitamin D", DateTime.Now.AddDays(-1)));
            _prescriptionRepo.Add(new Prescription(5, 3, "Aspirin", DateTime.Now.AddDays(-7)));
        }

        public void BuildPrescriptionMap()
        {
            var allPrescriptions = _prescriptionRepo.GetAll();
            _prescriptionMap = allPrescriptions
                .GroupBy(p => p.PatientId)
                .ToDictionary(g => g.Key, g => g.ToList());
        }

        public List<Prescription> GetPrescriptionsByPatientId(int patientId)
        {
            return _prescriptionMap.TryGetValue(patientId, out var prescriptions) 
                ? prescriptions 
                : new List<Prescription>();
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
                    Console.WriteLine($"- {p.MedicationName} (Issued: {p.DateIssued:d-MM-yyyy})");
                }
            }
            else
            {
                Console.WriteLine($"No prescriptions found for patient ID {id}");
            }
        }
    }
}