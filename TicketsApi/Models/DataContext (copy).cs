using Microsoft.EntityFrameworkCore;
using TicketsApi.Models;

public class DataContext : DbContext
{
    protected readonly IConfiguration Configuration;

    public DataContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // connect to postgres with connection string from app settings
        options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"));
    }

    public DbSet<User> Users { get; set; }

    public DbSet<TicketsApi.Models.Event> Event { get; set; } = default!;

    public DbSet<TicketsApi.Models.Location> Location { get; set; } = default!;

    public DbSet<TicketsApi.Models.Performer> Performer { get; set; } = default!;

    public DbSet<TicketsApi.Models.Ticket> Ticket { get; set; } = default!;

    public DbSet<TicketsApi.Models.Tour> Tour { get; set; } = default!;
}