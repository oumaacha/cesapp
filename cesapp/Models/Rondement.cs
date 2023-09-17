using System.ComponentModel.DataAnnotations;

namespace cesapp.Models
{
    public class Rondement
    {
        [Key]
        public int RondmentId { get; set; }
        public DateTime Date { get; set; }
        public decimal SC_En_Metre { get; set; }
        public decimal SD_En_Metre { get; set; }
        public int EssaiPressiometrique { get; set; }
        public int SPT { get; set; }
        public decimal CPT_En_MetreLineaire { get; set; }
        public int MachineId { get; set; }
        public int? ChantierId { get; set; }
        public int OperateurId { get; set; }
        public Machine Machine { get; set; }
        public Chantier Chantier { get; set; }
        public Operateur Operateur { get; set; }
    }
}
