namespace AkkaNet.ActorsSample.Models
{
    public class UpdateTagsMessage
    {
        public UpdateTagsMessage(string deviceId)
        {
            this.DeviceId = deviceId;
        }

        public string DeviceId { get; }
    }
}
