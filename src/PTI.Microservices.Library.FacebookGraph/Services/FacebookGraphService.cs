using Microsoft.Extensions.Logging;
using PTI.Microservices.Library.Configuration;
using PTI.Microservices.Library.Interceptors;
using PTI.Microservices.Library.Models.FacebookGraph.GetAlbumPhotos;
using PTI.Microservices.Library.Models.FacebookGraph.GetMyAlbums;
using PTI.Microservices.Library.Models.FacebookGraph.GetMyPhotos;
using System;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;

namespace PTI.Microservices.Library.Services
{
    /// <summary>
    /// Service in charge of exposing access to Facebook Graph API
    /// </summary>
    public class FacebookGraphService
    {
        private ILogger<FacebookGraphService> Logger { get; }
        private FacebookGraphConfiguration FacebookGraphConfiguration { get; }
        private CustomHttpClient CustomHttpClient { get; }

        /// <summary>
        /// Creates a new instance of <see cref="FacebookGraphService"/>
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="facebookGraphConfiguration"></param>
        /// <param name="customHttpClient"></param>
        public FacebookGraphService(ILogger<FacebookGraphService> logger,
            FacebookGraphConfiguration facebookGraphConfiguration, CustomHttpClient customHttpClient)
        {
            this.Logger = logger;
            this.FacebookGraphConfiguration = facebookGraphConfiguration;
            this.CustomHttpClient = customHttpClient;
        }

        /// <summary>
        /// Retrives the photos for the user
        /// </summary>
        /// <param name="pageToken"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<GetMyPhotosResponse> GetMyPhotosAsync(string pageToken = null,CancellationToken cancellationToken=default)
        {
            try
            {
                string requestUrl = $"{this.FacebookGraphConfiguration.Endpoint}/me" +
                    $"/photos" +
                    $"?type=uploaded" +
                    $"&fields=id,name,created_time,link,picture,webp_images" +
                    $"&access_token={this.FacebookGraphConfiguration.AccessToken}";
                if (!String.IsNullOrWhiteSpace(pageToken))
                {
                    requestUrl += $"&after={pageToken}";
                }
                var result = await this.CustomHttpClient.GetFromJsonAsync<GetMyPhotosResponse>(requestUrl, cancellationToken);
                return result;
            }
            catch (Exception ex)
            {
                this.Logger?.LogError(ex.Message, ex);
                throw;
            }
        }

        /// <summary>
        /// Get the albums for the user
        /// </summary>
        /// <param name="pageToken"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<GetMyAlbumsResponse> GetMyAlbumsAsync(string pageToken = null, CancellationToken cancellationToken = default)
        {
            try
            {
                string requestUrl = $"{this.FacebookGraphConfiguration.Endpoint}" +
                    $"/me/albums" +
                    $"?fields=id,created_time,name,description,count,link" +
                    $"&access_token={this.FacebookGraphConfiguration.AccessToken}";
                if (!String.IsNullOrWhiteSpace(pageToken))
                    requestUrl += $"&after={pageToken}";
                var result= await this.CustomHttpClient.GetFromJsonAsync<GetMyAlbumsResponse>(requestUrl, cancellationToken);
                return result;
            }
            catch (Exception ex)
            {
                this.Logger?.LogError(ex.Message, ex);
                throw;
            }
        }

        /// <summary>
        /// Gets the photos of the specified album
        /// </summary>
        /// <param name="albumId"></param>
        /// <param name="pageToken"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<GetAlbumPhotosResponse> GetAlbumPhotosAsync(string albumId,string pageToken = null, CancellationToken cancellationToken = default)
        {
            try
            {
                string requestUrl = $"{this.FacebookGraphConfiguration.Endpoint}" +
                    $"/{albumId}/photos" +
                    $"?fields=id,link,webp_images" +
                    $"&access_token={this.FacebookGraphConfiguration.AccessToken}";
                if (!String.IsNullOrWhiteSpace(pageToken))
                    requestUrl += $"&after={pageToken}";
                var result = await this.CustomHttpClient.GetFromJsonAsync<GetAlbumPhotosResponse>(requestUrl, cancellationToken);
                return result;
            }
            catch (Exception ex)
            {
                this.Logger?.LogError(ex.Message, ex);
                throw;
            }
        }

    }
}
