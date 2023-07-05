using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketsApi.Models;

public class NewEventPerfomer
{
    public List<long> performerIds { get; set; } = new List<long>();
}