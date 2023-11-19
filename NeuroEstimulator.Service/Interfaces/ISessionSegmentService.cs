using NeuroEstimulator.Domain.ViewModels;

namespace NeuroEstimulator.Service.Interfaces; 

public interface ISessionSegmentService
{
    public SessionSegmentViewModel SetSmgDetected(Guid id);
    public SessionSegmentViewModel SetEmergency(Guid id);
}
