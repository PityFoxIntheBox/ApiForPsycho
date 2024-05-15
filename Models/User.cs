using System;
using System.Collections.Generic;

namespace ApiForPsycho.Models;

public partial class User
{
    User() 
    {
        UsersTests = new HashSet<UsersTest>();
    }

    public int UserId { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int IdRole { get; set; }

    public string Surname { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Patronymic { get; set; }

    public int? IdDoctor { get; set; }

    public virtual Role IdRoleNavigation { get; set; } = null!;

    public virtual ICollection<UsersTest> UsersTests { get; set; } = new List<UsersTest>();
}
