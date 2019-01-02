//-----------------------------------------------------------------------
// <copyright file="JobProgressRequest.cs" company="Tasty Codes">
//     Copyright (c) 2010 Chad Burggraf.
// </copyright>
//-----------------------------------------------------------------------

namespace Zencoder
{
    using System;
    using System.Globalization;
    using Newtonsoft.Json;

    /// <summary>
    /// Implements the job progress request.
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class JobProgressRequest : Request<JobProgressRequest, JobProgressResponse>
    {
        private long jobId;
        private Uri url;

        /// <summary>
        /// Initializes a new instance of the JobProgressRequest class.
        /// </summary>
        /// <param name="zencoder">The <see cref="Zencoder"/> service to create the request with.</param>
        public JobProgressRequest(Zencoder zencoder)
            : base(zencoder)
        {
        }

        /// <summary>
        /// Initializes a new instance of the JobProgressRequest class.
        /// </summary>
        /// <param name="apiKey">The API key to use when connecting to the service.</param>
        /// <param name="baseUrl">The service base URL.</param>
        public JobProgressRequest(string apiKey, Uri baseUrl)
            : base(apiKey, baseUrl)
        {
        }

        /// <summary>
        /// Gets or sets the ID of the <see cref="Output"/> to get progress for.
        /// </summary>
        public long JobId
        {
            get
            {
                return this.jobId;
            }

            set
            {
                this.jobId = value;
                this.url = null;
            }
        }

        /// <summary>
        /// Gets the concrete URL this request will call.
        /// </summary>
        public override Uri Url
        {
            get
            {
                if (this.url == null)
                {
                    if (this.jobId < 1)
                    {
                        throw new InvalidOperationException("JobId must be set before generating the request URL.");
                    }

                    string path = string.Format(CultureInfo.InvariantCulture, "jobs/{0}/progress", this.JobId);
                    this.url = BaseUrl.AppendPath(path).WithApiKey(ApiKey);
                }

                return this.url;
            }
        }

        /// <summary>
        /// Gets the HTTP verb to use when making the request.
        /// </summary>
        public override string Verb
        {
            get { return "GET"; }
        }
    }
}
