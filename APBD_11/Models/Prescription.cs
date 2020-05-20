using System;
using System.Collections.Generic;

namespace APBD_11.Models
{
    public class Prescription
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public DateTime DueDate { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }

        

        
    }
}