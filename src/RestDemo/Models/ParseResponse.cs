namespace RestDemo.Models
{
    // Represents the JSON response returned by the API.
    public class ParseResponse
    {
        // Initializes a new ParseResponse instance.
        public ParseResponse(string input, string output)
        {
            Input = input;
            Output = output;
        }

        // The original old phone keypad input string.
        public string Input { get; private set; }

        // The parsed text result generated from the keypad input.
        public string Output { get; private set; }
    }
}