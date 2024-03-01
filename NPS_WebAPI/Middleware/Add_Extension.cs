namespace NPS_WebAPI.Middleware
{
    public static class Add_Extension
    {
        public static IApplicationBuilder UseCustomExceptionHandler(this
          IApplicationBuilder builder)
        {
            return builder.UseMiddleware<Custom_Exception_Handler_Middleware>();
        }
    }
}
