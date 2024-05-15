using System;
using System.Collections.Generic;

namespace ApiForPsycho.Models;

public partial class Question
{
    public int QuestionId { get; set; }

    public string? Content { get; set; }

    public int? IdTest { get; set; }

    public int? IdAnswer { get; set; }

    public virtual Answer? IdAnswerNavigation { get; set; }

    public virtual Test? IdTestNavigation { get; set; }
}
