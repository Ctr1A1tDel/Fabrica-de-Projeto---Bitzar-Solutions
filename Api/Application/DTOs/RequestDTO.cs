using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Application.DTOs
{
    public class RequestDTO
    {
        public string Propt { get; set; }
        public IFormFile File { get; set; } 
    }
}