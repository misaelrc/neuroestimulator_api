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
        public double Amplitude { get; set; }
        public double Frequency { get; set; }
        public double PulseWidth { get; set; }
        public double StimulationTime { get; set; }

        public int Difficulty { get; set; }
        public int Intensity { get; set; }
    }
}
