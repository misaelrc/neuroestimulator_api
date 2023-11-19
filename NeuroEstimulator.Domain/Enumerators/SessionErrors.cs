using NeuroEstimulator.Framework.Enumerators;

namespace NeuroEstimulator.Domain.Enumerators;

public class SessionErrors : Enumeration
{
    public SessionErrors(int id, string code, string name) : base(id, code, name) { }

    public static SessionErrors ErrorOnCreateSession = new SessionErrors(1, "SS001", "Erro ao criar sessão.");
    public static SessionErrors SessionNotFound = new SessionErrors(1, "SS002", "Sessão não encontrada.");
    public static SessionErrors ErrorOnAddSegment = new SessionErrors(1, "SS003", "Erro ao adicionar segmento.");

}
