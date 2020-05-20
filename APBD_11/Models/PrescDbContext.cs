using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;


namespace APBD_11.Models
{
    public class PrescDbContext : DbContext
    {
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }

        public DbSet<Patient> Patients { get; set; }

        public DbSet<Medicament> Medicaments { get; set; }

       

        public PrescDbContext()
        {
            
        }

        public PrescDbContext(DbContextOptions options)
        :base(options){
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            addDoctors(modelBuilder);
            addMedicament(modelBuilder);
            addPatients(modelBuilder);
            addPresc(modelBuilder);
            addPrescMedicaments(modelBuilder);
        }

       
        
        
        private void SeedSampleData()
        {
            
           
            
            
            
        }

        private void addDoctors(ModelBuilder modelBuilder)
        {
            var doctors = new List<Doctor>();
            doctors.Add(new Doctor {Id = 1, FirstName = "Kuba", LastName = "Kowalski", Email = "jsk.pl"});
            doctors.Add(new Doctor {Id = 2, FirstName = "Jakub", LastName = "Naumow", Email = "jsdaddn.com"});
            doctors.Add(new Doctor {Id = 3, FirstName = "Marcin", LastName = "Nowak", Email = "mlasdasddsml.pl"});
            modelBuilder.Entity<Doctor>().HasData(doctors);
        }

        private void addPatients(ModelBuilder modelBuilder)
        {
            var patients = new List<Patient>();

            patients.Add(new Patient
                {Id = 1, FirstName = "Ania", LastName = "3213", BirthDate = DateTime.Parse("1998-12-11")});
            patients.Add(new Patient
                {Id = 2, FirstName = "Andrzej", LastName = "12312", BirthDate = DateTime.Parse("1995-06-86")});
            patients.Add(new Patient
                {Id = 3, FirstName = "Staszel", LastName = "1323123", BirthDate = DateTime.Parse("1993-01-10")});
            modelBuilder.Entity<Patient>().HasData(patients);
        }

        private void addPresc(ModelBuilder modelBuilder)
        {
            var prescriptions = new List<Prescription>();
            prescriptions.Add(new Prescription
                {Id = 1, Date = DateTime.Now, DueDate = DateTime.Now.AddMonths(1), DoctorId = 1, PatientId = 3});
            prescriptions.Add(new Prescription
                {Id = 2, Date = DateTime.Now, DueDate = DateTime.Now.AddMonths(1), DoctorId = 2, PatientId = 2});
            prescriptions.Add(new Prescription
                {Id = 3, Date = DateTime.Now, DueDate = DateTime.Now.AddMonths(1), DoctorId = 3, PatientId = 1});
            modelBuilder.Entity<Prescription>().HasData(prescriptions);
        }

        private void addMedicament(ModelBuilder modelBuilder)
        {
            var medicaments = new List<Medicament>();
            medicaments.Add(new Medicament {Id = 1, Name = "nospa", Description = "na bol", Type = "lek"});
            medicaments.Add(new Medicament {Id = 2, Name = "apap", Description = "na bol glowy", Type = "lek"});
            medicaments.Add(new Medicament
                {Id = 3, Name = "witaminka", Description = "na odpornosc", Type = "lek"});
            modelBuilder.Entity<Medicament>().HasData(medicaments);
        }

        private void addPrescMedicaments(ModelBuilder modelBuilder)
        {
            var prescriptionMedicaments = new List<PrescriptionMedicament>();
            prescriptionMedicaments.Add(new PrescriptionMedicament {PrescriptionId = 3, MedicamentId = 1});
            prescriptionMedicaments.Add(new PrescriptionMedicament {PrescriptionId = 2, MedicamentId = 2});
            prescriptionMedicaments.Add(new PrescriptionMedicament {PrescriptionId = 1, MedicamentId = 3});
           
           
            modelBuilder.Entity<PrescriptionMedicament>().HasData(prescriptionMedicaments);
        }
    
    }
}