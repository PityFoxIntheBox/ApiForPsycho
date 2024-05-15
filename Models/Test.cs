using System;
using System.Collections.Generic;

namespace ApiForPsycho.Models;

public partial class Test
{
    public Test()
    {
        Questions = new HashSet<Question>();
        Results = new HashSet<Result>();
    }

    public int TestId { get; set; }

    public string TestName { get; set; } = null!;

    public int? QuestionsCount { get; set; }

    public string? Description { get; set; }

    public byte[]? Image { get; set; }

    public int? IdCategory { get; set; }

    public virtual Category? IdCategoryNavigation { get; set; }

    public virtual ICollection<Question> Questions { get; set; } = new List<Question>();

    public virtual ICollection<Result> Results { get; set; } = new List<Result>();
}
