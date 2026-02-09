using System;
using System.Collections.Generic;

namespace Bookmaster.Models;

public partial class Subject
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public virtual ICollection<BookSubject> BookSubjects { get; set; } = new List<BookSubject>();
}
