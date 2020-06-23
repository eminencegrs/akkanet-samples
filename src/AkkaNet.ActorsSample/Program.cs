using System;
using Akka.Actor;
using AkkaNet.ActorsSample.Actors;
using AkkaNet.ActorsSample.Models;

namespace AkkaNet.ActorsSample
{
    class Program
    {
        static void Main(string[] args)
        {
            var actorSystem = ActorSystem.Create("sample");

            // Options 1:
            var actor = actorSystem.ActorOf<ProvisioningActor>();
            actor.Tell(new RegistrationMessage("1"));

            // Options 2:
            //var target = actorSystem.ActorOf<ProvisioningActor>();
            //var inbox = Inbox.Create(actorSystem);
            //inbox.Send(target, new RegistrationMessage("1"));

            Console.ReadKey();
        }
    }
}
