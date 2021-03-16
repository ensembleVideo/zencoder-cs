//-----------------------------------------------------------------------
// <copyright file="JobProgressResponse.cs" company="Tasty Codes">
//     Copyright (c) 2010 Chad Burggraf.
// </copyright>
//-----------------------------------------------------------------------

namespace Zencoder
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// Implements the job progress response.
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class JobProgressResponse : Response<JobProgressRequest, JobProgressResponse>
    {
        /// <summary>
        /// Gets or sets the input progress for the current job.
        /// </summary>
        [JsonProperty("input")]
        public InputProgressResponse Input { get; set; }
        
        /// <summary>
        /// Gets or sets the output progress for the current job.
        /// </summary>
        [JsonProperty("outputs")]
        public OutputProgressResponse[] Outputs { get; set; }

        /// <summary>
        /// Gets or sets the progress of the Job
        /// </summary>
        [JsonProperty("progress")]
        public double Progress { get; set; }

        /// <summary>
        /// Gets or sets the output's current state.
        /// </summary>
        [JsonProperty("state")]
        public JobState State { get; set; }
    }
}
