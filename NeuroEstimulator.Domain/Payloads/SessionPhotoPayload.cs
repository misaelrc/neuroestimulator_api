using Microsoft.AspNetCore.Http;

namespace NeuroEstimulator.Domain.Payloads;

public class SessionPhotoPayload
{
    public Guid SessionId { get; set; }
    public IFormFile file { get; set; }
}
