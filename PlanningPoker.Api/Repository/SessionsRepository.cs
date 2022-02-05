using Microsoft.EntityFrameworkCore;
using PlanningPoker.Core;
using PlanningPoker.Core.Entities;
using System.Security.Cryptography;
using System.Text;

namespace PlanningPoker.Api.Repository
{
    public class SessionsRepository : ISessionsRepository
    {
        private readonly ILogger<SessionsRepository> _logger;
        private readonly PlanningPokerDbContext _dbContext;

        public SessionsRepository(
            ILogger<SessionsRepository> logger,
            PlanningPokerDbContext dbContext
        )
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<List<Session>> GetAllAsync()
        {
            _logger.LogInformation("Retrieving all Session records");
            var sessions = await _dbContext.Sessions.ToListAsync();
            _logger.LogInformation($"Found [{sessions.Count}] Session records");
            return sessions;
        }

        public async Task<Session> CreateAsync(Session session)
        {
            session.Id = Guid.NewGuid();
            session.CreatedAt = DateTimeOffset.UtcNow;
            session.UpdatedAt = DateTimeOffset.UtcNow;
            var md5Password = ConvertPasswordToMD5(session.Password);
            if (!string.IsNullOrEmpty(md5Password))
            {
                session.Password = md5Password;
            }

            await _dbContext.Sessions.AddAsync(session);
            await _dbContext.SaveChangesAsync();
            return session;
        }

        public async Task<Session?> GetOneAsync(Guid id)
        {
            var session = await _dbContext.Sessions.FindAsync(id);                
            return session;
        }

        public async Task<Session> UpdateAsync(Session entity)
        {
            entity.Password = ConvertPasswordToMD5(entity.Password);
            entity.UpdatedAt = DateTimeOffset.UtcNow;
            _dbContext.Sessions.Update(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(Session session)
        {
            _dbContext.Sessions.Remove(session);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var session = await _dbContext.Sessions.FindAsync(id);
            if (session != null)
            {
                await DeleteAsync(session);
            }
        }

        protected static string? ConvertPasswordToMD5(string inputPassword)
        {
            if (string.IsNullOrEmpty(inputPassword))
            {
                return null;
            }

            using HashAlgorithm algorithm = SHA256.Create();
            var md5Bytes = algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputPassword));

            StringBuilder sb = new StringBuilder();
            foreach (byte b in md5Bytes)
            {
                sb.Append(b.ToString("X2"));
            }
            return sb.ToString();
        }
    }
}
