using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuroEstimulator.Domain.Payloads
{
    public class PatientCreateSessionPayload
    {
        public Guid PatientId { get; set; }
        public ICollection<IFormFile> Files { get; set; }
    }
}
