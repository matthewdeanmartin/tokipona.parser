using System;
using System.Linq;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;

namespace Palmmedia.ReportGenerator.MSBuild
{
    /// <summary>
    /// MSBuild Task for generating reports.
    /// </summary>
    /// <example>
    /// &lt;?xml version="1.0" encoding="utf-8"?&gt;<br/>
    /// &lt;Project DefaultTargets="Coverage" xmlns="http://schemas.microsoft.com/developer/msbuild/2003" ToolsVersion="4.0"&gt;<br/>
    ///   &lt;UsingTask TaskName="ReportGenerator" AssemblyFile="ReportGenerator.exe" /&gt;<br/>
    ///   &lt;ItemGroup&gt;<br/>
    ///       &lt;CoverageFiles Include="partcover.xml" /&gt;<br/>
    ///   &lt;/ItemGroup&gt;<br/>
    ///   &lt;Target Name="Coverage"&gt;<br/>
    ///     &lt;ReportGenerator ReportFiles="@(CoverageFiles)" TargetDirectory="report" ReportType="Html" /&gt;<br/>
    ///   &lt;/Target&gt;<br/>
    /// &lt;/Project&gt;
    /// </example>
    public class ReportGenerator : Task, ITask
    {
        /// <summary>
        /// Gets or sets the report files.
        /// </summary>
        [Required]
        public ITaskItem[] ReportFiles { get; set; }

        /// <summary>
        /// Gets or sets the directory the report will be created in. This must be a directory, not a file. If the directory does not exist, it is created automatically. 
        /// </summary>
        [Required]
        public string TargetDirectory { get; set; }

        /// <summary>
        /// Gets or sets the type of the report.
        /// </summary>
        /// <value>The type of the report.</value>
        [Obsolete("The usage of the property 'ReportTypes' is preferred.")]
        public string ReportType { get; set; }

        /// <summary>
        /// Gets or sets the types of the report.
        /// </summary>
        /// <value>The types of the report.</value>
        public ITaskItem[] ReportTypes { get; set; }

        /// <summary>
        /// Gets or sets the source directories. Optional directories which contain the corresponding source code. The source files are used if coverage report contains classes without path information.
        /// </summary>
        /// <value>
        /// The source directories.
        /// </value>
        public ITaskItem[] SourceDirectories { get; set; }

        /// <summary>
        /// Gets or sets the assembly filters.
        /// </summary>
        /// <value>
        /// The assembly filters.
        /// </value>
        public ITaskItem[] Filters { get; set; }

        /// <summary>
        /// Gets or sets the verbosity level.
        /// </summary>
        /// <value>
        /// The verbosity level.
        /// </value>
        public string VerbosityLevel { get; set; }

        /// <summary>
        /// When overridden in a derived class, executes the task.
        /// </summary>
        /// <returns>
        /// true if the task successfully executed; otherwise, false.
        /// </returns>
        public override bool Execute()
        {
            string[] reportTypes = new string[] { };

            if (this.ReportTypes != null && this.ReportTypes.Length > 0)
            {
                reportTypes = this.ReportTypes.Select(r => r.ItemSpec).ToArray();
            }
            else if (this.ReportType != null)
            {
                reportTypes = new[] { this.ReportType };
            }

            ReportConfiguration configuration = new ReportConfiguration(
                this.ReportFiles == null ? Enumerable.Empty<string>() : this.ReportFiles.Select(r => r.ItemSpec),
                this.TargetDirectory,
                reportTypes,
                this.SourceDirectories == null ? Enumerable.Empty<string>() : this.SourceDirectories.Select(r => r.ItemSpec),
                this.Filters == null ? Enumerable.Empty<string>() : this.Filters.Select(r => r.ItemSpec),
                this.VerbosityLevel);

            return Program.Execute(configuration);
        }
    }
}
