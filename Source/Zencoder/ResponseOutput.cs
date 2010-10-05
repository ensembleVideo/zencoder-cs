﻿

namespace Zencoder
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// Represents an <see cref="Output"/> in a <see cref="CreateJobResponse"/>.
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class ResponseOutput
    {
        /// <summary>
        /// Gets or sets the output ID.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }
    }
}
