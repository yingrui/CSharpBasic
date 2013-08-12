using NUnit.Framework;

namespace CSharpBasic.Transcript
{
    public class Transcript
    {
        public string Name { get; set; }
        public int Chinese { get; set; }
        public int English { get; set; }

        public int TotalScore
        {
            get { return Chinese + English; }
        }
    }

    public class TranscriptTest
    {
        [Test]
        public void should_get_total_score()
        {
            var transcript = new Transcript
            {
                Name = "Li Lei",
                Chinese = 80,
                English = 80
            };
            Assert.AreEqual(160, transcript.TotalScore);
        }

        [Test]
        public void should_print_all_the_score_of_courses()
        {
            var transcript = new Transcript
            {
                Name = "Li Lei",
                Chinese = 80,
                English = 80
            };
//            Assert.AreEqual("Name: Li Lei, Chinese: 80, English: 80", transcript.Print());
        }
    }
}