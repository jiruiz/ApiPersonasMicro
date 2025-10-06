using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace UsersAPI.Models
{
    [Index(nameof(Email), IsUnique = true)] // solo el email es único
    public class User
    {
        [Key]
        public int IdUser { get; set; }

        [Required, MaxLength(50)]
        public string UserName { get; set; }

        [Required, MaxLength(100)]
        public string Email { get; set; }

        [Required, MaxLength(50)]
        public string UserLastName { get; set; }

        [Required, MaxLength(255)]
        public string UserPassword { get; set; }

        public DateTime InsertDate { get; set; } = DateTime.UtcNow;
        public DateTime? ModifyDate { get; set; }
        public bool Active { get; set; } = true;
        public DateTime? PasswordModifyDate { get; set; }
    }
}