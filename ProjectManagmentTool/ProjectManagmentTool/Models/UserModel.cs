using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectManagmentTool.Models
{
    public class UserModel
    {
        [Key]
        public int UserId { get; set; }
        [Required(ErrorMessage = "Please provide User Name .")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please provide your Mail address .")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please provide Password .")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Please provide Status")]
        public string Status { get; set; }
        [Required(ErrorMessage = "Please provide your Designation .")]
        public string Designation { get; set; }
    }
}