namespace Dashboard.API.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public int Age {get;set;}
        public int Weight {get;set;}
        public int Height {get;set;}
        public int BMI {get; set;}
        public int SystolicBP {get;set;}
        public int DiastolicPB {get;set;}
        public bool Statin {get;set;} 
        public bool HeartMeds {get; set;}       
       
    }
}