using Clean.Domain.Entities;
using Clean.Domain.Exceptions.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Domain.Exceptions
{
    public sealed class WebinarNotFoundException : NotFoundException
    {
        public WebinarNotFoundException(int webinarId) 
            : base($"The webinar with the identifier {webinarId} was not found.")
        {
        }
    }
}
