using Exiled.API.Features;
using Exiled.API.Interfaces;
using System.ComponentModel;
using static NTFOutroMusicReborn.AudioManager;

namespace NTFOutroMusicReborn
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; } = false;

        [Description("The path to the music / 音乐文件路径")]
        public string MusicPath { get; set; } = Paths.Exiled + "\\We_Gotta_Run.ogg";

        [Description("The type of broadcast to use. (Global or OnlyMTF) / 音频的广播类型。（Global或OnlyMTF）")]
        public AudioBroadcastType BroadcastType { get; set; } = AudioBroadcastType.OnlyMTF;
    }
}