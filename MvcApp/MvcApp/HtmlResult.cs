using Microsoft.AspNetCore.Mvc;

namespace MvcApp
{
    public class HtmlResult : ActionResult
    {
        string htmlCode;

        public HtmlResult(string html) => htmlCode = html;

        public override void ExecuteResult(ActionContext context)
        {
            string fullHtmlCode = @$"<!DOCTYPE html>
            <html>
                <head>
                    <title>METANIT.COM</title>
                    <meta charset=utf-8 />
                </head>
                <body>{htmlCode} 8</body>
            </html>";
            var task = context.HttpContext.Response.WriteAsync(fullHtmlCode);
            task.GetAwaiter().GetResult();
        }
    }
}
