using System;
using System.Threading.Tasks;
using Akka.Actor;
using AkkaNet.ActorsSample.Models;
using Newtonsoft.Json;

namespace AkkaNet.ActorsSample.Actors
{
    public class TagsActor : ReceiveActor
    {
        public TagsActor()
        {
            this.ReceiveAsync<UpdateTagsMessage>(async message =>
            {
                try
                {
                    Console.WriteLine($"Started updating device tags. Message: {JsonConvert.SerializeObject(message)}\n\n");

                    // Emulate some logic...
                    await Task.CompletedTask;

                    Console.WriteLine($"Step 2/2. Finished updating brewer twin tags. Message: {JsonConvert.SerializeObject(message)}\n\n");

                    var msg = new TagsUpdatedMessage(message.DeviceId);

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
