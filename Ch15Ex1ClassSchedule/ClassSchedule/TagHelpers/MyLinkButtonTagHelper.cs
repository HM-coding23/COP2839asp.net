using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.AspNetCore.Routing;

namespace ClassSchedule.TagHelpers
{
    [HtmlTargetElement("my-link-button")]
    public class MyLinkButtonTagHelper : TagHelper
    {
        private LinkGenerator linkGenerator { get; set; }

        public MyLinkButtonTagHelper(LinkGenerator lg)
        {
            linkGenerator = lg;
        }

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; } = null!;

        public string? Action { get; set; }
        public string? Controller { get; set; }
        public string? Id { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            string action = Action ?? ViewContext.RouteData.Values["action"]?.ToString() ?? "Index";
            string controller = Controller ?? ViewContext.RouteData.Values["controller"]?.ToString() ?? "Home";
            object? id = string.IsNullOrEmpty(Id) ? null : new { id = Id };

            string url = linkGenerator.GetPathByAction(ViewContext.HttpContext,
                action, controller, id) ?? "#";

            string currentId = ViewContext.RouteData.Values["id"]?.ToString() ?? "";
            string css = (!string.IsNullOrEmpty(Id) && currentId == Id)
                ? "btn btn-dark" : "btn btn-outline-dark";

            output.BuildLink(url, css);
        }
    }
}
