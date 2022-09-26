using Core.Persistence.Repositories;

namespace Core.Security.Entities;

public class UserOperationClaim : Entity
{
    public int UserId { get; set; }
    public int OperationClaimId { get; set; }
    public DateTime CreateDate { get; set; }

    public virtual User User { get; set; }
    public virtual OperationClaim OperationClaim { get; set; }

    public UserOperationClaim()
    {
    }

    public UserOperationClaim(int id, int userId, int operationClaimId, DateTime createDate) : base(id)
    { 
        UserId = userId;
        OperationClaimId = operationClaimId;
        CreateDate = createDate;    
    }
}