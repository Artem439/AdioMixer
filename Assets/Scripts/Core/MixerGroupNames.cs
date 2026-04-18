namespace Core
{
    public class MixerGroupNames
    {
        private const string MasterVolume = "MasterVolume";
        private const string ButtonsVolume = "ButtonsVolume";
        private const string BackgroundVolume = "BgVolume";
    
        public static string GetName(MixerGroups type)
        {
            return type switch
            {
                MixerGroups.Master => MasterVolume,
                MixerGroups.Button => ButtonsVolume,
                MixerGroups.Background => BackgroundVolume
            };
        }
    }
}