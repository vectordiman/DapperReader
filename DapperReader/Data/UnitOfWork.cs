using System;
using System.Data;
using DapperReader.Interfaces;

namespace DapperReader.Data;

public class UnitOfWork: IUnitOfWork, IDisposable
{
    public ICoachRepository CoachRepository { get; }
    
    public IAthleteRepository AthleteRepository { get; }

    private IDbTransaction _dbTransaction;
    
    public UnitOfWork(IDbTransaction dbTransaction, ICoachRepository coachRepository, IAthleteRepository athleteRepository)
    {
        CoachRepository = coachRepository;
        AthleteRepository = athleteRepository;
        _dbTransaction = dbTransaction;
    }
    
    public void Commit()
    {
        try
        {
            _dbTransaction.Commit();
        }
        catch (Exception)
        {
            _dbTransaction.Rollback();
        }
    }

    public void Dispose()
    {
        _dbTransaction.Connection?.Close();
        _dbTransaction.Connection?.Dispose();
        _dbTransaction.Dispose();
    }
}