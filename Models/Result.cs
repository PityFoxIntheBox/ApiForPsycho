using System;
using System.Collections.Generic;

namespace ApiForPsycho.Models;

public partial class Result
{
    public Result() 
    { 
        UsersTests = new HashSet<UsersTest>();
    }

    public int ResultId { get; set; }

    public string ResultName { get; set; } = null!;

    public string? Description { get; set; }

    public int? IdTest { get; set; }

    public int ScoreCount { get; set; }

    public virtual Test? IdTestNavigation { get; set; }

    public virtual ICollection<UsersTest> UsersTests { get; set; } = new List<UsersTest>();
}
