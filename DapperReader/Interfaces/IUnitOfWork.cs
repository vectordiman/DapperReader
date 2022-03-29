namespace DapperReader.Interfaces;

public interface IUnitOfWork
{
    ICoachRepository CoachRepository { get; }
    
    IAthleteRepository AthleteRepository { get; }
    
    void Commit();
}