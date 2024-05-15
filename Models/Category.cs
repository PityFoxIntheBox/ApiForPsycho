using System;
using System.Collections.Generic;

namespace ApiForPsycho.Models;

public partial class Category
{
    public Category()
    {
        Tests = new HashSet<Test>();
    }

    public int CategoryId { get; set; }

    public string CategoryName { get; set; } = null!;

    public virtual ICollection<Test> Tests { get; set; } = new List<Test>();
}
