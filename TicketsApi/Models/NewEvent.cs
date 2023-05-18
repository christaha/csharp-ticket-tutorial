using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketsApi.Models;

public class Event
{
    [Key]
    public long EventId { get; set; }
    public long TicketsAvailable { get; set; }
    public long TicketsSold { get; set; }
    public long TicketsTotal { get; set; }
    public string EventName { get; set; } = string.Empty;

    public DateTime AddedTime { get; set; }
    public DateTime LiveTime { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime? EndTime { get; set; }

    public Location Location { get; set; } = null!;
    public long LocationId { get; set; }

    public long? TourId { get; set; }
    public Tour? Tour { get; set; }

    public ICollection<Performer> Performers { get; } = new List<Performer>();

    public ICollection<Ticket> Tickets { get; } = new List<Ticket>();

}