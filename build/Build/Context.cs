using System.Collections.Generic;

using Build.Common.Enums;

using Cake.Core;
using Cake.Frosting;

using Semver;

namespace Build
{
    public class Context : FrostingContext
    {
        public Context(ICakeContext context)
            : base(context)
        {
        }

        public App App { get; } = new();

        public General General { get; } = new();

        public Tests Tests { get; } = new();
    }

    public class General
    {
        public string ArtifactsDir => ".artifacts";

        public IList<string> ArtifactsToUploadToPipeline { get; } = new List<string>();

        public SemVersion ArtifactVersion { get; set; }

        public Branches CurrentBranch { get; set; }

        public string CurrentBranchName { get; set; }

        public bool IsLocal { get; set; }

        public string Name { get; } = "Demo";

        public string SolutionName { get; } = "Demo.sln";
    }

    public class App
    {
        public string BuildConfig { get; } = "Release";

        public string MainProject { get; } = @"src\Demo.Console\Demo.Console.csproj";
    }

    public class Tests
    {
        public string TestProjectName { get; } = "Demo.Tests";

        public string TestProject { get; } = @"tests\Demo.Tests\Demo.Tests.csproj";
    }
}
