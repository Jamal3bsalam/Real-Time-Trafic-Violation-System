using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraficViolation.GB.Application.Abstractions.AuditLog
{
    public interface IAuditLogService
    {
       public Task LogAsync(string userId, string actionType, string entityName, string entityId, string? oldValue, string? newValue);
    }
}
