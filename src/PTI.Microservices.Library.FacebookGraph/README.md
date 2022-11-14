# PTI.Microservices.Library.FacebookGraph

This is part of PTI.Microservices.Library set of packages

The purpose of this package is to facilitate the calls to Facebook Graph APIs, while maintaining a consistent usage pattern among the different services in the group

**Examples:**

## Get My Photos
    FacebookGraphService facebookGraphService =
        new FacebookGraphService(null,
        this.FaceBookGraphConfiguration,
        new Microservices.Library.Interceptors.CustomHttpClient(
            new Microservices.Library.Interceptors.CustomHttpClientHandler(
                null)));
    var result = await facebookGraphService.GetMyPhotosAsync();

## Get My Albums
    FacebookGraphService facebookGraphService =
        new FacebookGraphService(null,
        this.FaceBookGraphConfiguration,
        new Microservices.Library.Interceptors.CustomHttpClient(
            new Microservices.Library.Interceptors.CustomHttpClientHandler(
                null)));
    var result = await facebookGraphService.GetMyAlbumsAsync();

## Get Album Photos
    FacebookGraphService facebookGraphService =
        new FacebookGraphService(null,
        this.FaceBookGraphConfiguration,
        new Microservices.Library.Interceptors.CustomHttpClient(
            new Microservices.Library.Interceptors.CustomHttpClientHandler(
                null)));
    string albumId = TEST_ALBUM_ID;
    var result = await facebookGraphService.GetAlbumPhotosAsync(albumId);