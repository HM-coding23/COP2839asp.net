using Microsoft.AspNetCore.Razor.TagHelpers;

namespace ClassSchedule.TagHelpers
{
    [HtmlTargetElement("button", Attributes = "type")]
    public class SubmitButtonTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            string? type = output.Attributes["type"]?.Value?.ToString();

            if (type?.ToLower() == "submit") {
                output.Attributes.AppendCssClass("btn btn-dark");
            }
        }
    }
}
