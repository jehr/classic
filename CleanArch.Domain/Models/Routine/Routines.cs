using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Models.Routine
{
    public class Routines
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int LevelId { get; set; }
        public string Name { get; set; }
        public string Week { get; set; }
        [ForeignKey("LevelId")]
        public LevelRoutines LevelRoutines { get; set; }
    }
}
