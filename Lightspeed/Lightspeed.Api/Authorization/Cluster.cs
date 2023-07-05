namespace Lightspeed.Api.Authorization;

public class Cluster
{
    private readonly ClusterType _clusterType;
    
    public Cluster(ClusterType clusterType)
    {
        _clusterType = clusterType;
    }

    public override string ToString()
    {
        return GetClusterUrl();
    }

    public string GetClusterUrl()
    {
        return _clusterType switch
        {
            ClusterType.Eu => "https://api.webshopapp.com",
            ClusterType.Us => " https://api.shoplightspeed.com",
            _ => throw new ArgumentOutOfRangeException()
        };
    }
    
    public enum ClusterType
    {
        Eu,
        Us
    }
}