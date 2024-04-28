﻿using Newtonsoft.Json;
using NJsonSchema.NewtonsoftJson.Converters;

namespace WebScrapper.DOMAIN
{
    /// <summary>
    /// Represents a user model with email and password.
    /// </summary>
    /// 
    [JsonConverter(typeof(JsonInheritanceConverter), "type")]
    public class UserModel
    {
        /// <summary>
        /// Gets or sets the email of the user.
        /// </summary>
        public string Email { get; set; } = "";

        /// <summary>
        /// Gets or sets the password of the user.
        /// </summary>
        public string UserPassword { get; set; } = "";
    }
}