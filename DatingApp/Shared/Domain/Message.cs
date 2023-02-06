using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DatingApp.Shared.Domain
{
    public class Message : BaseDomainModel
    {
        [Required]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Wah lao so short meh")]
        public string MessageDesc { get; set; }
    }
}
