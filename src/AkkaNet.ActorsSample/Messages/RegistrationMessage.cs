namespace AkkaNet.ActorsSample.Models
{
    public class RegistrationMessage
    {
        public RegistrationMessage(string deviceId)
        {
            this.DeviceId = deviceId;
        }

        public string DeviceId { get; }
    }
}
