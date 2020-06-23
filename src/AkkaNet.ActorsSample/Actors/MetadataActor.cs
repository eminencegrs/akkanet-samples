using Akka.Actor;
using AkkaNet.ActorsSample.Models;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace AkkaNet.ActorsSample.Actors
{
    public class MetadataActor : ReceiveActor
    {
        public MetadataActor()
        {
            this.ReceiveAsync<GetMetadataMessage>(async message =>
            {
                try
                {
                    Console.WriteLine($"Started getting metadata. Message: {JsonConvert.SerializeObject(message)}\n\n");

                    var metadata = await Task.FromResult("metadata");

                    Console.WriteLine($"Step 1/2. Finished getting metadata. Message: {JsonConvert.SerializeObject(message)}\n\n");

                    var msg = new MetadataReceived(message.DeviceId);

                    var provisioningActor = Context.ActorOf(Props.Create(() => new ProvisioningActor()));

                    provisioningActor.Tell(msg, Self);
                }
                catch (Exception e)
                {
                    Sender.Tell(new Failure { Exception = e }, Self);
                }
            });
        }
    }
}
