
using System;
using System.Collections.Generic;
using System.Text;

namespace IronOldPhoneKeypad
{
    public class PhoneKeypad
    {
        // Maps each keypad number to the letters it represents on an old phone keypad.
        private static readonly Dictionary<char, string> KeypadMapping =
            new Dictionary<char, string>
        {
            { '2', "ABC" },
            { '3', "DEF" },
            { '4', "GHI" },
            { '5', "JKL" },
            { '6', "MNO" },
            { '7', "PQRS" },
            { '8', "TUV" },
            { '9', "WXYZ" }
        };

        // Converts an old phone keypad input string into its corresponding text.
        // Example: "33# " returns "E".
        //
        // Rules:
        // - '#' ends the input.
        // - '*' deletes the previous character.
        // - A space separates repeated key presses for different letters.
        public static string OldPhonePad(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return string.Empty;
            }
            else if (input.IndexOf('#') < 0)
            {
                throw new ArgumentException("Input must contain the '#' terminator.");
            }

            // Stores the final decoded text.
            StringBuilder output = new StringBuilder();

            // Stores the current sequence of repeated key presses.
            // For example, "222" represents the letter "C".
            StringBuilder current = new StringBuilder();

            // Tracks the previous key so the method knows when a new key sequence begins.
            char previous = '\0';

            foreach (char c in input)
            {
                // The # character marks the end of input.
                if (c == '#')
                {
                    if (current.Length > 0)
                    {
                        AppendCharacter(output, current);
                        current.Clear();
                    }

                    break;
                }

                // The * character works like backspace.
                if (c == '*')
                {
                    if (current.Length > 0)
                    {
                        AppendCharacter(output, current);
                        current.Clear();
                        previous = '\0';
                    }

                    if (output.Length > 0)
                    {
                        output.Length--;
                    }

                    continue;
                }

                // A space commits the current key sequence and allows the same key
                // to be used again for the next character.
                if (c == ' ')
                {
                    if (current.Length > 0)
                    {
                        AppendCharacter(output, current);
                        current.Clear();
                    }

                    previous = '\0';
                    continue;
                }

                // Only digits 2 through 9 are valid keypad characters.
                if (!KeypadMapping.ContainsKey(c))
                {
                    throw new ArgumentException(
                        string.Format("Invalid keypad character: {0}", c));
                }

                // When the key changes, commit the previous key sequence.
                if (c != previous && current.Length > 0)
                {
                    AppendCharacter(output, current);
                    current.Clear();
                }

                // Add the current key press to the active sequence.
                current.Append(c);
                previous = c;
            }

            // Commit any remaining sequence after the loop.
            if (current.Length > 0)
            {
                AppendCharacter(output, current);
            }

            return output.ToString();
        }

        // Converts a sequence of repeated key presses into a single character
        // and appends it to the output.
        private static void AppendCharacter(
            StringBuilder output,
            StringBuilder current)
        {
            string letters = KeypadMapping[current[0]];
            int index = (current.Length - 1) % letters.Length;

            output.Append(letters[index]);
        }
    }
}