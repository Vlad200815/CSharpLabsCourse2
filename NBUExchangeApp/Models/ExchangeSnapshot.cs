using System;
using System.Collections.Generic;

namespace NBUExchangeApp.Models;

public class ExchangeSnapshot
{
    public string DataSource { get; set; } = "";
    public string SourceUrl { get; set; } = "";
    public DateTimeOffset SavedAt { get; set; }
    public List<ExchangeReading> Readings { get; set; } = new();
}