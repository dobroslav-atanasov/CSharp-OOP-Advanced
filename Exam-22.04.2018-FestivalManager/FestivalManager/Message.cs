namespace FestivalManager
{
    public abstract class Message
    {
        public const string SongOverLimit = "Song is over the set limit!";

        public const string RegisterSet = "Registered {0} set";

        public const string SignUpPerformer = "Registered performer {0}";

        public const string RegisterSong = "Registered song {0} ({1}:{2})";
    }
}