using Core.Models.Common;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.Payment
{
    public class Payments 
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public DateTime DatePayment { get; set; }
        public DateTime NextDatePayment { get; set; } 
        public User.User User { get; set; }
    }
}
