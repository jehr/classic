using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Models.Valoration
{
    public class DetailsValoration
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ValorationId { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public int MeasureArmLeft { get; set; }
        public int MeasureArmRight { get; set; }
        public int MeasureForearmLeft { get; set; }
        public int MeasureForearmRight { get; set; }
        public int MeasureLegLeft { get; set; }
        public int MeasureLegRight { get; set; }
        public int MeasureCalfLeft { get; set; }
        public int MeasureCalfRight { get; set; }
        public int MeasureHead { get; set; }
        public int MeasureNeck { get; set; }
        public int MeasureChest { get; set; }
        public int MeasureBack { get; set; }
        public Valorations Valoration { get; set; }
    }
}
