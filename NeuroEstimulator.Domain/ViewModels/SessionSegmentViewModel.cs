namespace NeuroEstimulator.Domain.ViewModels;

public class SessionSegmentViewModel
{
    public Guid Id { get; set; }
    public int Difficulty { get; set; }
    public int Intensity { get; set; }
    public bool? SmgDetected { get; private set; }
    public bool? Emergency { get; private set; }
}
