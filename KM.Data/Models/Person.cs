using Km.Data.Models;
using System;
using System.Collections.Generic;

namespace KM.Data.Models;

public partial class Person
{
    public Guid Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public int? Age { get; set; }
}
