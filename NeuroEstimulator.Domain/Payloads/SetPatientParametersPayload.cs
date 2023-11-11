using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuroEstimulator.Domain.Payloads;

public class SetPatientParametersPayload
{
    public Guid PatientId { get; set; }
    public double Amplitude { get; set; }
    public double Frequency { get; set; }
    public double MaxPulseWidth { get; set; }
    public double MinPulseWidth { get; set; }
    public double StimulationTime { get; set; }
    public int Repetitions { get; set; }
}
