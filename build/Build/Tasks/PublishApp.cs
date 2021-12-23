using Build.Common.Enums;

using Cake.Common.Tools.DotNet;
using Cake.Common.Tools.DotNetCore.Publish;
using Cake.Frosting;

namespace Build
{
    public class PublishApp : FrostingTask<Context>
    {
        /// <summary>Runs the task using the specified context.</summary>
        /// <param name="context">The context.</param>
        public override void Run(Context context)
        {
            string versionSuffix;

            if (!context.General.IsLocal && context.General.CurrentBranch == Branches.Main)
            {
                versionSuffix = string.Empty;
            }
            else
            {
                versionSuffix = $"{context.General.ArtifactVersion.Prerelease}-{context.General.ArtifactVersion.Build}";
            }

            DotNetCorePublishSettings dotNetCorePublishSettings = new()
            {
                Configuration = "release",
                PublishSingleFile = true,
                SelfContained = true,
                //PublishTrimmed = true,
                PublishReadyToRun = true,
                Runtime = "win-x64",
                OutputDirectory = context.General.ArtifactsDir,
                VersionSuffix = versionSuffix
            };

            context.DotNetPublish(context.App.MainProject, dotNetCorePublishSettings);
        }
    }
}
