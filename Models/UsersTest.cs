using System;
using System.Collections.Generic;

namespace ApiForPsycho.Models;

public partial class UsersTest
{

    public int Id { get; set; }

    public int IdUser { get; set; }

    public int IdResult { get; set; }

    public virtual Result IdResultNavigation { get; set; } = null!;

    public virtual User IdUserNavigation { get; set; } = null!;
}
