using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuroEstimulator.Domain.Payloads
{
    public class SessionSegmentPayload
    {
        public Guid SessionId { get; set; }
        public int Difficulty { get; set; }
        public int Intensity { get; set; }
    }
}
