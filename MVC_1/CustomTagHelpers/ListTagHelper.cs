using Microsoft.AspNetCore.Razor.TagHelpers;
using MVC_1.Models;
using Coditas.EComm.Entities;

namespace MVC_1.CustomTagHelpers
{
    public class listgenerator : TagHelper
    {
        public IEnumerable<Category> categories { get; set; }
        public IEnumerable<Object> objectList { get; set; }
        //public override void Process(TagHelperContext context, TagHelperOutput output)
        //{

        //    output.TagName = "List";

        //    output.TagMode = TagMode.StartTagAndEndTag;

        //    var table = "<table class ='table table-bordered table-striped table-dark'>";

        //    foreach( var item in categories)
        //    {
        //        table += $"<tr><td>{item.CategoryId}</td><td>{item.CategoryName}</td><td>{item.BasePrice}</td></tr>";
        //    }

        //    table += "</table>";

        //    output.PreContent.SetHtmlContent(table);
        //}

        //public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        //{
        //    output.TagName = "List";

        //    output.TagMode = TagMode.StartTagAndEndTag;

        //    var table = "<table class ='table table-bordered table-striped table-dark'>";

        //    var a = objectList.GetType();
             
        //    foreach(var item in objectList)
        //    {
                
             
        //    }
            

        //}
    }
}
