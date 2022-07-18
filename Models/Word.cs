namespace CSharpRocks.Models
{
    public class Word
    { 
        public int Id { get; set; }

        public string Value { get; set; }

        public Word(int Id, string Value)
        {
            this.Id = Id;
            this.Value = Value;
        }

    }
}
