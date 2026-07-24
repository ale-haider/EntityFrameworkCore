using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameworkCore.Domain
{
    public class League : BaseDomainModel
    {
        // has its own id as inherited form BaseDomainModel

        public string? Name { get; set; }

    }
}
