using System;

namespace DapperReader.Entities;

public class Sport
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public DateTime Created { get; set; }
    public string? Description { get; set; }
}