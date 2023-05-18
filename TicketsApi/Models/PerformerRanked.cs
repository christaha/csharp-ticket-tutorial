using System;
using System.ComponentModel.DataAnnotations;

namespace TicketsApi.Models;

public class Performer
{
    public long PerformerId { get; set; }
    public string Name { get; set; } = string.Empty;

    public Event Events { get; set; }

    public ICollection<Tour>? Tours { get; set; }
}
