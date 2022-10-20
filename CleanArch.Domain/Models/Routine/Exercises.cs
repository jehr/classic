using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Models.Routine
{
    public class Exercises
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int RoutineId { get; set; }
        public int MuscularGroupId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [ForeignKey("RoutineId")]
        public Routines Routines { get; set; }
        [ForeignKey("MuscularGroupId")]
        public MuscularGroup MuscularGroup { get; set; }
    }
}
