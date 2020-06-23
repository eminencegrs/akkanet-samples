using System;
using System.Threading.Tasks;
using Akka.Actor;
using AkkaNet.ActorsSample.Models;
using Newtonsoft.Json;

namespace AkkaNet.ActorsSample.Actors
{
    public class ProvisioningActor : ReceiveActor
    {
        public ProvisioningActor()
        {
            this.ReceiveAsync<RegistrationMessage>(async message =>
            {
                Console.WriteLine($"Step 0/2. Provisioning has been started. Message: {JsonConvert.SerializeObject(message)}\n\n");

                // Emulate some logic...
                await Task.CompletedTask;

                var brewerMetadataActor = Context.ActorOf(Props.Create(() => new MetadataActor()));

                var getMetadataMessage = new GetMetadataMessage(message.DeviceId);

                brewerMetadataActor.Tell(getMetadataMessage, this.Self);
            });

            this.ReceiveAsync<MetadataReceived>(async message =>
            {
                // Emulate some logic...
                await Task.CompletedTask;

                var twinTagsActor = Context.ActorOf(Props.Create(() => new TagsActor()));

                var updateTwinTagsMessage = new UpdateTagsMessage(message.DeviceId);

                twinTagsActor.Tell(updateTwinTagsMessage, this.Self);
            });

            this.ReceiveAsync<TagsUpdatedMessage>(message =>
            {
                Console.WriteLine($"Provisioning has been finished. Message: {JsonConvert.SerializeObject(message)}\n\n");

                return Task.CompletedTask;
            });
        }

        protected override void PreStart()
        {
        }

        protected override void PreRestart(Exception reason, object message)
        {
            foreach (var child in Context.GetChildren())
            {
                Context.Unwatch(child);
                Context.Stop(child);
            }

            PostStop();
        }

        protected override void PostRestart(Exception reason)
        {
            PreStart();
        }

        protected override void PostStop()
        {
        }
    }
}
