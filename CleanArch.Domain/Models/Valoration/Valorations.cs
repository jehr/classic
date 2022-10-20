using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Models.Valoration
{
    public class Valorations
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public DateTime DateValoration { get; set; }
        public string Hour { get; set; }
        public bool Status { get; set; }
        public User.User User { get; set; }
    }
}
