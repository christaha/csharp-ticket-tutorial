using System;
using System.ComponentModel.DataAnnotations;

namespace TicketsApi.Models;

public class Performer
{
    [Key]
    public long PerformerId { get; set; }
    public string Name { get; set; } = string.Empty;

    public ICollection<Event> Events { get; } = new List<Event>();

    public ICollection<Tour>? Tours { get; } = new List<Tour>();
}
