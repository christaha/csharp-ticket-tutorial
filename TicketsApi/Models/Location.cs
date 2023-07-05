using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.AspNetCore.Http.HttpResults;

namespace TicketsApi.Models;

public class Location
{
    [Key]
    public long LocationId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public string Zipcode { get; set; } = string.Empty;
    public string? State { get; set; } = string.Empty;

    public ICollection<Event> Events { get; } = new List<Event>();
}