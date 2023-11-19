using NeuroEstimulator.Framework.Enumerators;

namespace NeuroEstimulator.Domain.Enumerators;

public class SegmentErrors : Enumeration
{
    public SegmentErrors(int id, string code, string name) : base(id, code, name) { }

    public static SegmentErrors SegmentNotFound = new SegmentErrors(1, "SG001", "Segmento não encontrado.");
    public static SegmentErrors ErrorOnSetSmgDetected = new SegmentErrors(1, "SG002", "Erro ao registrar Smg Detectado.");
    public static SegmentErrors ErrorOnSetEmergency = new SegmentErrors(1, "SG003", "Erro ao registrar emergência.");

}
