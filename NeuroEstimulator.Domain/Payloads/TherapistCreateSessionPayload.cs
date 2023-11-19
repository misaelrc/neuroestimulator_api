using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuroEstimulator.Domain.Payloads
{
    public class TherapistCreateSessionPayload
    {
        public Guid PatientId { get; set; }
        public double WristAmplitudeMeasurement { get; set; }
    }
}
