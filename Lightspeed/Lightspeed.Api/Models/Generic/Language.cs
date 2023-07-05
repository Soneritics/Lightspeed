namespace Lightspeed.Api.Models.Generic;

public class Language
{
    public int Id { get; set; }
    
    public string Code { get; set; } = string.Empty;
    
    public string Locale { get; set; } = string.Empty;
    
    public string Title { get; set; } = string.Empty;
}