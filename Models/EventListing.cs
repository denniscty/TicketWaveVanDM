using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketWave.Models;

public class EventListing
{
    public int EventListingID { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime Date { get; set; }
}
