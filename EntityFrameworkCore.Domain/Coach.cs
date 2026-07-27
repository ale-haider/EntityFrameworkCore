using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameworkCore.Domain
{
   public  class Coach : BaseDomainModel
    {
        //public int Id { get; set; }
        public string? Name { get; set; }

        //public int? TeamId { get; set; }

        public Team? Team { get; set; }
    }
}
