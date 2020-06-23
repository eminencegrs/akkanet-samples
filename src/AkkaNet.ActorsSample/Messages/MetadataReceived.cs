namespace AkkaNet.ActorsSample.Models
{
    public class MetadataReceived
    {
        public MetadataReceived(string deviceId)
        {
            this.DeviceId = deviceId;
        }

        public string DeviceId { get; }
    }
}
