using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuroEstimulator.Domain.ViewModels
{
    public class SessionParametersViewModel
    {
        public double Amplitude { get; private set; }
        public double Frequency { get; private set; }
        public double? MaxPulseWidth { get; private set; }
        public double? MinPulseWidth { get; private set; }
        public double StimulationTime { get; private set; }
    }
}
