using Core.Persistence.Repositories;

namespace Core.Security.Entities;

public class OperationClaim : Entity
{
    public string Name { get; set; }
    public DateTime CreateDate { get; set; }

    public OperationClaim()
    {
    }

    public OperationClaim(int id, string name , DateTime createDate) : base(id)
    {
        Name = name; 
        CreateDate = createDate; 
    }
}