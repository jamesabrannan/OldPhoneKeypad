using System;
using Xunit;

namespace IronOldPhoneKeypad.Tests
{
    public class PhoneKeypadTests
    {
        [Fact]
        public void OldPhonePad_ReturnsHello()
        {
            string result = PhoneKeypad.OldPhonePad("4433555 555666#");

            Assert.Equal("HELLO", result);
        }

        [Fact]
        public void OldPhonePad_ReturnsEmptyString_WhenInputIsEmpty()
        {
            string result = PhoneKeypad.OldPhonePad(string.Empty);

            Assert.Equal(string.Empty, result);
        }

        [Fact]
        public void OldPhonePad_RemovesPreviousCharacter_WhenBackspaceIsUsed()
        {
            string result = PhoneKeypad.OldPhonePad("227*#");

            Assert.Equal("B", result);
        }

        [Fact]
        public void OldPhonePad_ThrowsArgumentException_WhenInputContainsInvalidCharacter()
        {
            Assert.Throws<ArgumentException>(
                delegate { PhoneKeypad.OldPhonePad("44A#"); });
        }

        [Fact]
        public void OldPhonePad_HandlesConsecutiveSequences()
        {
            string result = PhoneKeypad.OldPhonePad("222#");

            Assert.Equal("C", result);
        }

        [Fact]
        public void OldPhonePad_StopsProcessing_WhenTerminatorIsFound()
        {
            string result = PhoneKeypad.OldPhonePad("33#777");

            Assert.Equal("E", result);
        }

        [Fact]
        public void OldPhonePad_StopsProcessing_HandlesAssignmentExample()
        {
            string result = PhoneKeypad.OldPhonePad("222 2 22#");

            Assert.Equal("CAB", result);
        }

        [Fact]
        public void OldPhonePad_StopsProcessing_HandlesAssignmentError()
        {
            Assert.Throws<ArgumentException>(
                delegate { PhoneKeypad.OldPhonePad("44A#"); });
        }
    }
}