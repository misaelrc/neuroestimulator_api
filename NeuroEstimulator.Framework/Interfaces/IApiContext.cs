using NeuroEstimulator.Framework.Diagnostics;
using NeuroEstimulator.Framework.Field;
using NeuroEstimulator.Framework.Filtering;
using NeuroEstimulator.Framework.Paging;
using NeuroEstimulator.Framework.Result;
using NeuroEstimulator.Framework.Security;
using NeuroEstimulator.Framework.Sorting;

namespace NeuroEstimulator.Framework.Interfaces;

/// <summary>
/// Interface do Contexto de trabalho do serviço
/// </summary>
public interface IApiContext
{
    /// <summary>
    /// HTTP status code específico a ser retornado ao fim da requisição. Opcional. 
    /// </summary>
    int? HttpStatusCode { get; set; }

    /// <summary>
    /// Lista de erros a ser retornado ao fim da requisição. Opcional.
    /// </summary>
    List<Error> Errors { get; }

    /// <summary>
    /// Ativa a telemetria do insights
    /// </summary>
    bool EnableTelemetry { get; set; }

    /// <summary>
    /// Identificador único de transação. Opcional.
    /// </summary>
    string TransactionId { get; set; }

    /// <summary>
    /// Contexto de instrumentação.
    /// </summary>
    InstrumentationContext InstrumentationContext { get; }

    /// <summary>
    /// Contexto de paginação.
    /// </summary>
    PagingContext PagingContext { get; }

    /// <summary>
    /// Contexto de ordenação.
    /// </summary>
    SortingContext SortingContext { get; }

    /// <summary>
    /// Contexto de segurança
    /// </summary>
    SecurityContext SecurityContext { get; }

    /// <summary>
    /// Contexto de filtro
    /// </summary>
    FilteringContext FilteringContext { get; }

    /// <summary>
    /// Contexto de seleção de campos
    /// </summary>
    FieldContext FieldContext { get; }
}
