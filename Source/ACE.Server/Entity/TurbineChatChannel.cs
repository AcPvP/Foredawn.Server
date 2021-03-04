namespace ACE.Server.Entity
{
    public static class TurbineChatChannel
    {
        public static uint General              = 1;
        public static uint Trade                = 2;
        public static uint LFG                  = 3;
        public static uint Roleplay             = 4;

        public static uint Allegiance           = 5;

        public static uint Olthoi               = 6;

        public static uint Society              = 7;

        public static uint SocietyCelestialHand = 8;
        public static uint SocietyEldrytchWeb   = 9;
        public static uint SocietyRadiantBlood  = 10;
    }

    public enum TurbineChatChannel_Enum : uint
    {
        General = 1,
        Trade = 2,
        LFG = 3,
        Roleplay = 4,
        Allegiance = 5,
        Olthoi = 6,
        Society = 7,
        SocietyCelestialHand = 8,
        SocietyEldrytchWeb = 9,
        SocietyRadiantBlood = 10
    }
}
