﻿namespace NeuroEstimulator.Domain.ViewModels;

public class ListPatientViewModel
{
    public ListPatientViewModel() { }

    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime BirthDate { get; set; }
    
}
