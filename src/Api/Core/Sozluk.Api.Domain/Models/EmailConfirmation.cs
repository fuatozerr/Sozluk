using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sozluk.Api.Domain.Models
{
    public class EmailConfirmation:BaseEntity
    {
        public string OldEmailAdress { get; set; }
        public string NewEmailAddress { get; set; }

    }
}
