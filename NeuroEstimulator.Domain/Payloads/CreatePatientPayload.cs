﻿namespace NeuroEstimulator.Domain.Payloads;

public class CreatePatientPayload
{
    public string Login { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }

    public DateTime BirthDate { get; set; }

    public string? CaretakerName { get; set; }
    public string? CaretakerPhone { get; set; }
}
