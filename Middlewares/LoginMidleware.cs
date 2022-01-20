using System.Diagnostics;
namespace MiddlewareNet5.Middlewares
{
    public class LoginMidleware
    {
        private readonly RequestDelegate _next;
        public LoginMidleware(RequestDelegate next)
        {
            this._next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            using var buffer = new MemoryStream();
            var request = context.Request;
            var response = context.Response;
            var stream = response.Body;
            response.Body = buffer;
            await _next(context);
            Debug.Writeline("request content type: {0} {1} {2} {3} {4}", request.Scheme, request.Host, request.Querry, request.Body, request.Path);
            buffer.Position = 0;
            await buffer.CopyToSync(stream);
        }
    }
    
}