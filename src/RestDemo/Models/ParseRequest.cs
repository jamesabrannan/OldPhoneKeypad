namespace RestDemo.Models
{
    // Represents the JSON request body sent to the API.
    // 
    // Example:
    // {
    //     "input": "4433555 555666#"
    // }
    public class ParseRequest
    {
        // The old phone keypad input string to parse.
        public string Input { get; set; }
    }
}
