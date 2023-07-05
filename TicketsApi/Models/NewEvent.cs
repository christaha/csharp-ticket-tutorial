using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketsApi.Models;

public class NewEvent
{
    public string EventName { get; set; } = string.Empty;

    public DateTime LiveTime { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime? EndTime { get; set; }

    public long LocationId { get; set; }
}