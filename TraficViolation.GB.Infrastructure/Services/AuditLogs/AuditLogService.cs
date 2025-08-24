using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraficViolation.GB.Application.Abstractions.AuditLog;
using TraficViolation.GB.Application.Abstractions.UnitOfWork;
using TraficViolation.GB.Domain.Entities;
using TraficViolation.GB.Infrastructure.Data.Context;

namespace TraficViolation.GB.Infrastructure.Services.AuditLogs
{
    public class AuditLogService : IAuditLogService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AuditLogService(IUnitOfWork unitOfWork )
        {
            _unitOfWork = unitOfWork;
        }
        public async Task LogAsync(string userId, string actionType, string entityName, string entityId, string? oldValue, string? newValue)
        {
            var auditLog = new AuditLog()
            {
                UserId = userId,
                ActionType = actionType,
                EntityName = entityName,
                RecordId = entityId,
                OldValues = oldValue,
                NewValues = newValue,
                Timestamp = DateTime.UtcNow
            };

           await _unitOfWork.Repository<AuditLog,int>().AddAsync(auditLog);
           await _unitOfWork.CompleteAsync();
        }
    }
}
