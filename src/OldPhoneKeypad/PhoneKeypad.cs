
using System;
using System.Collections.Generic;
using System.Text;

namespace IronOldPhoneKeypad
{
    public class PhoneKeypad
    {
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

        public static string OldPhonePad(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return string.Empty;
            }

            StringBuilder output = new StringBuilder();
            StringBuilder current = new StringBuilder();

            char previous = '\0';

            foreach (char c in input)
            {
                if (c == '#')
                {
                    if (current.Length > 0)
                    {
                        AppendCharacter(output, current);
                        current.Clear();
                    }

                    break;
                }

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

                if (!KeypadMapping.ContainsKey(c))
                {
                    throw new ArgumentException(
                        string.Format("Invalid keypad character: {0}", c));
                }

                if (c != previous && current.Length > 0)
                {
                    AppendCharacter(output, current);
                    current.Clear();
                }

                current.Append(c);
                previous = c;
            }

            if (current.Length > 0)
            {
                AppendCharacter(output, current);
            }

            return output.ToString();
        }

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