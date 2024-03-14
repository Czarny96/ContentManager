namespace ContentManager.Api;

public static class HttpContextExtensions
{
    public static string GetUserId(this HttpContext httpContext)
    {
        if (httpContext.User is null)
        {
            return string.Empty;
        }

        return httpContext.User.Claims.Single(x => x.Type == "id").Value;
    }
}