namespace NTFOutroMusicReborn
{
    public static class AudioManager
    {
        public enum AudioBroadcastType : sbyte
        {
            Global = 0,
            OnlyMTF = 1,
        }

        public static void PlayAudio(AudioBroadcastType broadcastType = AudioBroadcastType.Global)
        {
            AudioPlayer audioPlayer = null;

            if (broadcastType == AudioBroadcastType.Global)
            {
                audioPlayer = AudioPlayer.CreateOrGet($"Global AudioPlayer", onIntialCreation: (p) =>
                {
                    Speaker speaker = p.AddSpeaker("[Global Speaker]" + "OutroMusic", 2f, isSpatial: false, maxDistance: 5000f);
                    speaker.Volume = 2f;
                });
            }

            if (broadcastType == AudioBroadcastType.OnlyMTF)
            {
                audioPlayer = AudioPlayer.CreateOrGet($"MTF AudioPlayer", condition: (hub) =>
                {
                    return hub.roleManager.CurrentRole.Team == PlayerRoles.Team.FoundationForces || hub.roleManager.CurrentRole.Team == PlayerRoles.Team.Scientists;
                }
                , onIntialCreation: (p) =>
                {
                    Speaker speaker = p.AddSpeaker("[MTF Speaker]" + "OutroMusic", 2f, isSpatial: false, maxDistance: 5000f);
                    speaker.Volume = 2f;
                });
            }

            audioPlayer.AddClip("OutroMusic", 2f);
        }
    }
}