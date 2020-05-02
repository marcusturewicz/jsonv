using System;
using Xunit;
using JsonValidate;

namespace JsonValidate.Tests
{
    public class Tests
    {
        [Fact]
        public void InvalidForNonExistentFile()
        {
            var (valid, error) = Program.ValidateJson("doesnotexists.json", false);
            Assert.False(valid);
            Assert.Equal("File does not exist!", error);
        }

        [Fact]
        public void InvalidForInvalidFile()
        {
            var (valid, error) = Program.ValidateJson("invalid.json", false);
            Assert.False(valid);
            Assert.NotNull(error);
        }

        [Fact]
        public void ValidForValidFileWithCommentsAllowingComments()
        {
            var (valid, error) = Program.ValidateJson("with-comments.json", true);
            Assert.True(valid);
            Assert.Equal(string.Empty, error);
        }

        [Fact]
        public void InvalidForValidFileWithCommentsDisallowingComments()
        {
            var (valid, error) = Program.ValidateJson("with-comments.json", false);
            Assert.False(valid);
            Assert.NotNull(error);
        }

        [Fact]
        public void ValidForValidFileWithoutCommentsAllowingComments()
        {
            var (valid, error) = Program.ValidateJson("without-comments.json", true);
            Assert.True(valid);
            Assert.Equal(string.Empty, error);
        }

        [Fact]
        public void ValidForValidFileWithoutCommentsDisallowingComments()
        {
            var (valid, error) = Program.ValidateJson("without-comments.json", false);
            Assert.True(valid);
            Assert.Equal(string.Empty, error);
        }
    }
}
