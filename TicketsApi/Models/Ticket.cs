using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketsApi.Models;

public class Ticket
{
    public long TicketId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Seat { get; set; } = string.Empty;

    public long EventId { get; set; }

    [ForeignKey("EventId")]
    public Event Event { get; set; } = null!;

    public long UserId { get; set; }

    [ForeignKey("UserId")]
    public User? User { get; set; } = null!;
}
