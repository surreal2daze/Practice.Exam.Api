using Microsoft.EntityFrameworkCore.Storage;
using Practice.Api.Declarations;

namespace Practice.Exam.Api
{
    public sealed class TestingCustomDbContextTransaction : IDbContextTransaction
    {
        private readonly IDbContextTransaction _transaction;
        private readonly IUnitOfWorkService _unitOfWorkService;

        public TestingCustomDbContextTransaction(
            IDbContextTransaction transaction,
            IUnitOfWorkService unitOfWorkService)
        {
            _transaction = transaction;
            _unitOfWorkService = unitOfWorkService;
        }

        public Task RollbackAsync(CancellationToken cancellationToken = new CancellationToken())
            => _transaction.RollbackAsync(cancellationToken);

        public Guid TransactionId => _transaction.TransactionId;

        public void Commit() => _transaction.Commit();

        public void Dispose() => _transaction.Dispose();

        public void Rollback()
        {
            try
            {
                _unitOfWorkService.SaveChanges();
                _transaction.Rollback();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public Task CommitAsync(CancellationToken cancellationToken = new CancellationToken())
            => _transaction.CommitAsync(cancellationToken);

        public ValueTask DisposeAsync() => _transaction.DisposeAsync();
    }
}