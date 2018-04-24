namespace FestivalManager.Core.Controllers
{
    using System;
    using System.Linq;
    using System.Text;
    using Contracts;
    using Entities.Contracts;
    using Entities.Factories.Contracts;

    public class FestivalController : IFestivalController
    {
        private IStage stage;
        private ISetFactory setFactory;
        private IInstrumentFactory instrumentFactory;
        private IPerformerFactory performerFactory;
        private ISongFactory songFactory;

        public FestivalController(IStage stage, ISetFactory setFactory, IInstrumentFactory instrumentFactory,
            IPerformerFactory performerFactory, ISongFactory songFactory)
        {
            this.stage = stage;
            this.setFactory = setFactory;
            this.instrumentFactory = instrumentFactory;
            this.performerFactory = performerFactory;
            this.songFactory = songFactory;
        }

        public string ProduceReport()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Results:");

            TimeSpan totalDuration = new TimeSpan();
            foreach (ISet set in this.stage.Sets)
            {
                foreach (ISong song in set.Songs)
                {
                    totalDuration += song.Duration;
                }
            }

            int totalSeconds = (int) totalDuration.TotalSeconds;

            if (totalSeconds >= 60)
            {
                int seconds = totalSeconds % 60;
                int minutes = totalSeconds / 60;

                sb.AppendLine($"Festival length: {minutes:D2}:{seconds:D2}");
            }
            else
            {
                sb.AppendLine($"Festival length: {totalDuration.Minutes:D2}:{totalDuration.Seconds:D2}");
            }


            foreach (ISet set in this.stage.Sets)
            {
                int totalSecondsCurrentSet = (int) set.ActualDuration.TotalSeconds;

                if (totalSecondsCurrentSet >= 60)
                {
                    int seconds = totalSecondsCurrentSet % 60;
                    int minutes = totalSecondsCurrentSet / 60;
                    sb.AppendLine($"--{set.Name} ({minutes:D2}:{seconds:D2}):");
                }
                else
                {
                    sb.AppendLine($"--{set.Name} ({set.ActualDuration.Minutes:D2}:{set.ActualDuration.Seconds:D2}):");
                }

                foreach (IPerformer performer in set.Performers.OrderByDescending(p => p.Age))
                {
                    sb.AppendLine(
                        $"---{performer.Name} ({string.Join(", ", performer.Instruments.OrderBy(i => i.IsBroken))})");
                }

                if (set.Songs.Count == 0)
                {
                    sb.AppendLine("--No songs played");
                }
                else
                {
                    sb.AppendLine($"--Songs played:");
                    foreach (ISong song in set.Songs)
                    {
                        sb.AppendLine($"----{song}");
                    }
                }
            }

            return sb.ToString().Trim();
        }

        public string RegisterSet(string[] args)
        {
            string name = args[0];
            string type = args[1];
            ISet set = this.setFactory.CreateSet(name, type);
            this.stage.AddSet(set);

            return string.Format(Message.RegisterSet, type);
        }

        public string SignUpPerformer(string[] args)
        {
            var name = args[0];
            var age = int.Parse(args[1]);

            var instrumenti = args.Skip(2).ToArray();

            var instrumenti2 = instrumenti
                .Select(i => this.instrumentFactory.CreateInstrument(i))
                .ToArray();

            var performer = this.performerFactory.CreatePerformer(name, age);

            foreach (var instrument in instrumenti2)
            {
                performer.AddInstrument(instrument);
            }

            this.stage.AddPerformer(performer);

            return string.Format(Message.SignUpPerformer, name);
        }

        public string RegisterSong(string[] args)
        {
            string name = args[0];
            string[] parts = args[1].Split(new[] {':'}, StringSplitOptions.RemoveEmptyEntries);
            int minutes = int.Parse(parts[0]);
            int seconds = int.Parse(parts[1]);

            ISong song = this.songFactory.CreateSong(name, new TimeSpan(0, minutes, seconds));
            this.stage.AddSong(song);

            return string.Format(Message.RegisterSong, name, $"{minutes:D2}", $"{seconds:D2}");
        }

        public string AddSongToSet(string[] args)
        {
            var songName = args[0];
            var setName = args[1];

            if (!this.stage.HasSet(setName))
            {
                throw new InvalidOperationException("Invalid set provided");
            }

            if (!this.stage.HasSong(songName))
            {
                throw new InvalidOperationException("Invalid song provided");
            }

            var set = this.stage.GetSet(setName);
            var song = this.stage.GetSong(songName);

            set.AddSong(song);

            return $"Added {song} to {set.Name}";
        }

        public string AddPerformerToSet(string[] args)
        {
            string performerName = args[0];
            string setName = args[1];

            if (!this.stage.HasPerformer(performerName))
            {
                throw new InvalidOperationException("Invalid performer provided");
            }

            if (!this.stage.HasSet(setName))
            {
                throw new InvalidOperationException("Invalid set provided");
            }

            var performer = this.stage.GetPerformer(performerName);
            var set = this.stage.GetSet(setName);

            set.AddPerformer(performer);

            return $"Added {performerName} to {setName}";
        }

        public string RepairInstruments(string[] args)
        {
            var instrumentsToRepair = this.stage.Performers
                .SelectMany(p => p.Instruments)
                .Where(i => i.Wear < 100)
                .ToArray();

            foreach (var instrument in instrumentsToRepair)
            {
                instrument.Repair();
            }

            return $"Repaired {instrumentsToRepair.Length} instruments";
        }
    }
}