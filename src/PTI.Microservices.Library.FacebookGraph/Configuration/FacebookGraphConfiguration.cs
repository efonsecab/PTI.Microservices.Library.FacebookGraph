using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTI.Microservices.Library.Configuration
{
    /// <summary>
    /// Configuration for Facebook Graph
    /// </summary>
    public class FacebookGraphConfiguration
    {
        /// <summary>
        /// Base endpoint for Facebook Graph
        /// </summary>
        public string Endpoint { get; set; } = "https://graph.facebook.com/v11.0";
        /// <summary>
        /// Access token
        /// </summary>
        public string AccessToken { get; set; }
    }
}
