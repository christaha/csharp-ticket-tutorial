using System;
using System.ComponentModel.DataAnnotations;

namespace TicketsApi.Models;

public class User
{
    public long UserId { get; set; }
    public string Username { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;

    public ICollection<Ticket> Tickets { get; } = new List<Ticket>();
}

