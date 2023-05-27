using System;
using System.ComponentModel.DataAnnotations;


namespace Fitness_Tracking.Models
{
    public class UserModel
    {
        public int UserId { get; set; }

        [StringLength(15), MinLength(2)]
        public string FirstName { get; set; }

        [StringLength(15), MinLength(2)]
        public string Surname { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Password { get; set; }

        public DateTime LastAuthorizationDate { get; set; }

        public int FailedAuthorizationAttempts { get; set; }
    }
}
