using Huginn.Database.Common;
using Microsoft.Extensions.Logging;

namespace Huginn.Database.Extensions;

public static partial class LoggerExtensions
{
    [LoggerMessage(Level = LogLevel.Debug, Message = "{EntityName} with ID {EntityId} has been created.")]
    public static partial void LogEntityAdded(this ILogger logger, string entityName, Guid entityId);

    [LoggerMessage(Level = LogLevel.Error, Message = "Cannot create {EntityName} with ID {EntityId}.", SkipEnabledCheck = true)]
    public static partial void LogEntityAddError(this ILogger logger, string entityName, Guid entityId, Exception exception);
    
    [LoggerMessage(Level = LogLevel.Debug, Message = "{EntityName} with ID {EntityId} has been updated.")]
    public static partial void LogEntityUpdated(this ILogger logger, string entityName, Guid entityId);

    [LoggerMessage(Level = LogLevel.Error, Message = "Cannot update {EntityName} with ID {EntityId}.", SkipEnabledCheck = true)]
    public static partial void LogEntityUpdateError(this ILogger logger, string entityName, Guid entityId, Exception exception);
    
    [LoggerMessage(Level = LogLevel.Debug, Message = "{EntityName} with ID {EntityId} has been deleted.")]
    public static partial void LogEntityDeleted(this ILogger logger, string entityName, Guid entityId);

    [LoggerMessage(Level = LogLevel.Error, Message = "Cannot delete {EntityName} with ID {EntityId}.", SkipEnabledCheck = true)]
    public static partial void LogEntityDeleteError(this ILogger logger, string entityName, Guid entityId, Exception exception);
}
