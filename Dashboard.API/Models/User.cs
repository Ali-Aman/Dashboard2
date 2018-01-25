using System.Collections.Generic;
namespace Dashboard.API.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName {get;set;}
        public string LastName {get;set;}
        public string Address {get;set;}
        public string City {get; set;}
        public string Province {get;set;}
        public string PostalCode {get;set;}
        public string Email {get;set;}
        public string Username {get; set;}
        public byte[] PasswordSalt {get;set;}
        public byte[] PasswordHash { get; set; }



        public List<Patient> Patients {get; set;}

    }
}