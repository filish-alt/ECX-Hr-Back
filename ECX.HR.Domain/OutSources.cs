using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Domain
{
    public class OutSources
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PId { get; set; }
        [Key]

        public Guid Id { get; set; }
        public string File { get; set; }
        public string Remark { get; set; }
        public double Amount { get; set; }
        public DateTime Date { get; set; }
 
        public int Status { get; set; }
    }
}
