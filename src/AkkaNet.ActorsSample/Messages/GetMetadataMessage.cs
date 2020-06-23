namespace AkkaNet.ActorsSample.Models
{
    public class GetMetadataMessage
    {
        public GetMetadataMessage(string deviceId)
        {
            this.DeviceId = deviceId;
        }

        public string DeviceId { get; }
    }
}
