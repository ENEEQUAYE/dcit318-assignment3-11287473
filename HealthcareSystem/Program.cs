namespace HealthcareSystem
{
    public class Program
    {
        public static void Main()
        {
            var app = new HealthSystemApp();
            app.SeedData();
            app.BuildPrescriptionMap();
            app.PrintAllPatients();
            
            // Print prescriptions for first patient
            app.PrintPrescriptionsForPatient(1);
        }
    }
}