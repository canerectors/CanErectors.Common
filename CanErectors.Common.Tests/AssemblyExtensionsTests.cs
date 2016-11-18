using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.PlatformAbstractions;
using Xunit;

namespace CanErectors.Common.Tests
{
    public class AssemblyExtensionsTests : IDisposable
    {
        public AssemblyExtensionsTests()
        {
            if (!Directory.Exists(testFolder))
                Directory.CreateDirectory(testFolder);
        }

        private static string testFolderName = "testfiles";
        private static string testFolder = Path.Combine(PlatformServices.Default.Application.ApplicationBasePath, testFolderName);

        [Fact]
        public void ShouldEmitEmbeddedTestFile()
        {
            var fileName = "EmbeddedResource.testfile";

            var basePath = testFolder;

            var filePath = Path.Combine(basePath, fileName);

            Assert.NotEqual(File.Exists(filePath), true);

            typeof(AssemblyExtensionsTests).Assembly.EmitResources(fileName, basePath);

            Assert.Equal(File.Exists(filePath), true);
        }

        [Fact]
        public void ShouldNotOverwriteExistingFileByDefault()
        {
            var fileName = "EmbeddedResource.testfile";

            var basePath = testFolder;

            var filePath = Path.Combine(basePath, fileName);

            Assert.NotEqual(File.Exists(filePath), true);

            var originalContents = "this is a test";

            File.WriteAllText(filePath, originalContents);

            Assert.Equal(File.Exists(filePath), true);

            typeof(AssemblyExtensionsTests).Assembly.EmitResources(fileName, basePath);

            var contents = File.ReadAllText(filePath);

            Assert.Equal(originalContents, contents);
        }

        [Fact]
        public void ShouldOverwriteExistingFileWhenAsked()
        {
            var fileName = "EmbeddedResource.testfile";

            var basePath = testFolder;

            var filePath = Path.Combine(basePath, fileName);

            Assert.NotEqual(File.Exists(filePath), true);

            var originalContents = "this is a test";

            File.WriteAllText(filePath, originalContents);

            Assert.Equal(File.Exists(filePath), true);

            typeof(AssemblyExtensionsTests).Assembly.EmitResources(fileName, basePath, true);

            var contents = File.ReadAllText(filePath);

            Assert.NotEqual(originalContents, contents);
        }

        //TODO pattern matching tests

        public void Dispose()
        {
            Directory.Delete(testFolder, true);
        }
    }
}
