using Exiled.API.Features;
using MEC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoAlphaWarhead
{
    public class Plugin : Plugin<Config>
    {
        public static Plugin plugin;
        public override string Author => "Zolics";
        public override string Prefix => "auto_warhead";
        public override string Name => "AutoWarhead";
        public CoroutineHandle handle = default(CoroutineHandle);
        public int TimeStart = 0;
        public override void OnEnabled()
        {
            Exiled.Events.Handlers.Server.RoundStarted += OnRoundStarted;
            Exiled.Events.Handlers.Server.WaitingForPlayers += OnWaitingForPlayers;
            base.OnEnabled();
        }
        public override void OnDisabled()
        {
            Exiled.Events.Handlers.Server.RoundStarted -= OnRoundStarted;
            Exiled.Events.Handlers.Server.WaitingForPlayers -= OnWaitingForPlayers;
            base.OnDisabled();
        }
        public void OnWaitingForPlayers()
        {
            TimeStart = 0;
            Timing.KillCoroutines(handle);
        }
        public void OnRoundStarted()
        {
            handle = Timing.RunCoroutine(WarheadHandle());
        }
        public IEnumerator<float> WarheadHandle()
        {
            while(Round.IsStarted)
            {
                TimeStart++;
                if(TimeStart == Plugin.plugin.Config.WarheadTime)
                {
                    Map.Broadcast(10, Plugin.plugin.Config.Text);
                    Warhead.DetonationTimer = 90f;
                    Warhead.IsLocked = true;
                    Warhead.Start();
                }
                yield return Timing.WaitForSeconds(1f);
            }
        }
    }
}
