namespace FestivalManager.Tests
{
    using Core.Controllers;
    using Core.Controllers.Contracts;
    using Entities;
    using Entities.Contracts;
    using Entities.Instruments;
    using Entities.Sets;
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class SetControllerTests
    {
        private IStage stage;
        private ISetController setController;

        [SetUp]
        public void SetUp()
        {
            this.stage = new Stage();
            this.setController = new SetController(this.stage);
        }

        [Test]
        public void TestMessageWhenSetIsSuccessful()
        {
            IInstrument instrument = new Guitar();

            IPerformer performer = new Performer("Ivan", 20);
            performer.AddInstrument(instrument);

            ISong song = new Song("Song1", new TimeSpan(0, 1, 2));
            this.stage.AddSong(song);

            ISet set = new Short("Set1");
            this.stage.AddSet(set);
            set.AddPerformer(performer);
            set.AddSong(song);

            string message = this.setController.PerformSets().Trim();
            string output = "1. Set1:" + Environment.NewLine + "-- 1. Song1 (01:02)" + Environment.NewLine +
                            "-- Set Successful";

            Assert.That(message, Is.EqualTo(output));
        }

        [Test]
        public void TestMessageWhenSetDidNotPerform()
        {
            IPerformer performer = new Performer("Ivan", 20);

            ISong song = new Song("Song1", new TimeSpan(0, 1, 2));
            this.stage.AddSong(song);

            ISet set = new Short("Set1");
            this.stage.AddSet(set);
            set.AddPerformer(performer);
            set.AddSong(song);

            string message = this.setController.PerformSets().Trim();
            string output = "1. Set1:" + Environment.NewLine + "-- Did not perform";

            Assert.That(message, Is.EqualTo(output));
        }

        [Test]
        public void TestWearOfInstrument()
        {
            IInstrument instrument = new Guitar();

            IPerformer performer = new Performer("Ivan", 20);
            performer.AddInstrument(instrument);

            ISong song = new Song("Song1", new TimeSpan(0, 1, 2));
            this.stage.AddSong(song);

            ISet set = new Short("Set1");
            this.stage.AddSet(set);
            set.AddPerformer(performer);
            set.AddSong(song);

            this.setController.PerformSets();

            Assert.That(instrument.Wear, Is.EqualTo(40));
        }
    }
}