using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class AccountModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AccountNumber { get; set; }

        public string AccType { get; set; }

        public string IFSC { get; set; }

        public string SecurityPIN { get; set; }

        public int balance { get; set; }

        //navigation property

        public int UserId { get; set; }
        public UsernewModel User { get; set; }
    }
}
