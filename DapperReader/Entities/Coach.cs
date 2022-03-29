using System.Collections.Generic;

namespace DapperReader.Entities;

public class Coach
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    
    public List<Sport>? Sports { get; set; }
}