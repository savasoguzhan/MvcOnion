using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcOnion.Application.Dtos.AuthorDtos
{
    public class AuthorCreateDto
    {
        public string FirstName { get; set; }
        public string LastName{ get; set; }

        public DateTime CreateDate { get; set; } = DateTime.Now;

        public bool IsActive => true;
    }
}
