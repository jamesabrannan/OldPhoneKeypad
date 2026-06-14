namespace RestDemo.Models
{
    public class ParseResponse
    {
        public ParseResponse(string input, string output)
        {
            Input = input;
            Output = output;
        }

        public string Input { get; private set; }

        public string Output { get; private set; }
    }
}