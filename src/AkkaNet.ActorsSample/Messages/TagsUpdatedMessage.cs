namespace AkkaNet.ActorsSample.Models
{
    public class TagsUpdatedMessage
    {
        public TagsUpdatedMessage(string deviceId)
        {
            this.DeviceId = deviceId;
        }

        public string DeviceId { get; }
    }
}
