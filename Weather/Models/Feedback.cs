using System;
using System.Collections.Generic;

namespace Weather.Models;

public partial class Feedback
{
    public Guid Id { get; set; }

    public string? Rating { get; set; }

    public string? Comment { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
