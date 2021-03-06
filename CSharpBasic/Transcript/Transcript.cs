using NUnit.Framework;

namespace CSharpBasic.Transcript
{
    public class Transcript
    {
        [Display]
        public string Name { get; set; }
        public int Age { get; set; }
        [Display]
        public int? Chinese { get; set; }
        [Display]
        public int? English { get; set; }
        [Display]
        public int? Math { get; set; }

        public int TotalScore
        {
            get { return Chinese.GetValueOrDefault(0) + English.GetValueOrDefault(0) + Math.GetValueOrDefault(0); }
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
                English = 80,
                Math = 80
            };
            Assert.AreEqual(240, transcript.TotalScore);
        }

        [Test]
        public void should_get_total_score_except_unregisted_courses()
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
        public void should_print_all_the_score_of_courses_except_unregisted_courses()
        {
            var transcript = new Transcript
            {
                Name = "Li Lei",
                Chinese = 80,
                English = 81
            };
            Assert.AreEqual("Name: Li Lei, Chinese: 80, English: 81", transcript.Print());
        }

        [Test]
        public void should_print_all_the_score_of_courses()
        {
            var transcript = new Transcript
            {
                Name = "Li Lei",
                Chinese = 80,
                English = 81,
                Math = 82
            };
            Assert.AreEqual("Name: Li Lei, Chinese: 80, English: 81, Math: 82", transcript.Print());
        }

        [Test]
        public void should_merge_valid_score_to_transcript()
        {
            var transcript = new Transcript
            {
                Name = "Li Lei",
                Chinese = 80,
                English = 81
            };
            var other = new Transcript
            {
                Name = "Li Lei",
                Math = 90
            };
            transcript.Merge(other);
            Assert.AreEqual(80, transcript.Chinese);
            Assert.AreEqual(81, transcript.English);
            Assert.AreEqual(90, transcript.Math);
        }
    }
}