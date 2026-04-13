namespace Sound
{
    public enum MixerGroups
    {
        Master,
        Button,
        Background
    }
    
    public static class MixerGroupNames
    {
        public static string GetName(MixerGroups type)
        {
            return type switch
            {
                MixerGroups.Master => "MasterVolume",
                MixerGroups.Button => "ButtonsVolume",
                MixerGroups.Background => "BgVolume"
            };
        }
    }
}