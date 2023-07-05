using System;
using System.ComponentModel.DataAnnotations;

namespace TicketsApi.Models;

public class Tour
{
    public long TourId { get; set; }
    public string Name { get; set; } = string.Empty;


    public ICollection<Performer> Performers { get; } = new List<Performer>();

    public ICollection<Event> Events { get; } = new List<Event>();
}