using Exiled.API.Features;
using Exiled.Events.EventArgs.Server;
using System;

namespace NTFOutroMusicReborn
{
    public class Plugin : Plugin<Config>
    {
        public override string Name { get; } = "NTFOutroMusicReborn";
        public override string Author { get; } = "XingYeNotFish";
        public override Version Version { get; } = new Version(1, 0, 0);

        public static Plugin Instance;

        public override void OnEnabled()
        {
            Instance = this;
            base.OnEnabled();
            Exiled.Events.Handlers.Server.RespawningTeam += RespawningTeam;
            AudioClipStorage.LoadClip(Instance.Config.MusicPath, "OutroMusic");
            Log.Info("Plugin has been enabled! / 插件已启用!");
        }

        public override void OnDisabled()
        {
            Instance = null;
            base.OnDisabled();
            Exiled.Events.Handlers.Server.RespawningTeam -= RespawningTeam;
            Log.Info("Plugin has been disabled! / 插件已关闭!");
        }

        public void RespawningTeam(RespawningTeamEventArgs ev)
        {
            if (ev.Wave.Faction == PlayerRoles.Faction.FoundationStaff)
            {
                AudioManager.PlayAudio(Instance.Config.BroadcastType);
            }
        }
    }
}