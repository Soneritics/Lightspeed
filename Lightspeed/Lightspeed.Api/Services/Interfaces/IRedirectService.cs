namespace Lightspeed.Api.Services.Interfaces;

public interface IRedirectService
{
    Task CreateRedirectAsync(string url, string target, bool isPermanent = true);
}