namespace MiddlewareNet5.Middlewares
{
    public static class CustomMidlewareExtension
    {
        public static IApplicationBuilder UseCustomMidleware(this IApplicationBuilder builder)
        {
            return builder.UseMidleware<LoginMidleware>();
        }
        
    }
}