using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketsApi.Models;

public class NewTicket
{
    public string Name { get; set; } = string.Empty;
    public string Seat { get; set; } = string.Empty;
    public long EventId { get; set; }
}