using Stateless;
using Stateless.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.BPSC.ShopPracz.Models
{
    public class Lamp
    {
        // public LampState State { get; set; }

        public LampState State => machine.State;

        private StateMachine<LampState, Trigger> machine;

        public Lamp()
        {
            machine = new StateMachine<LampState, Trigger>(LampState.Off);

            machine.Configure(LampState.Off)
                .Permit(Trigger.Switch, LampState.On);

            machine.Configure(LampState.On)
                .Permit(Trigger.Switch, LampState.Blink)
                .Permit(Trigger.Stop, LampState.Off)
                .OnEntry(() => Console.WriteLine("wlaczono"), "wyslij powitanie")
                .OnExit(() => Console.WriteLine("THX"), "wyslij pozegnanie");
                ;

            machine.Configure(LampState.Blink)
                .Permit(Trigger.Switch, LampState.Off);

            string graph = UmlDotGraph.Format(machine.GetInfo());

        }

        public void Switch()
        {
            machine.Fire(Trigger.Switch);
        }

        public void Stop()
        {
            machine.Fire(Trigger.Stop);
        }

    }
   

    public enum LampState
    {
        Off,
        On,
        Blink
    }

    public enum Trigger
    {
        Switch,

        Stop
    }

}
