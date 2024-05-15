using System;
using System.Collections.Generic;

namespace ApiForPsycho.Models;

public partial class Answer
{
    public Answer() 
    { 
        Questions = new HashSet<Question>();
    }

    public int AnswerId { get; set; }

    public string AnswerName { get; set; } = null!;

    public virtual ICollection<Question> Questions { get; set; } = new List<Question>();
}
