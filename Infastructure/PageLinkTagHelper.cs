using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineBooks.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
//using OnlineBooks.Models.ViewModels.PagingInfo;

namespace OnlineBooks.Infastructure
{
    //inherit from tag helper
    [HtmlTargetElement("div", Attributes = "page-model")]
    public class PageLinkTagHelper : TagHelper
    {
        private IUrlHelperFactory urlHelperFactory;
        
        //constructor
        public PageLinkTagHelper (IUrlHelperFactory hp)
        {
            //store so the whole class can see it
            urlHelperFactory = hp;
        }
        
        //properties
        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }
        public PagingInfo PageModel { get; set; }
        public string PageAction { get; set; }

        [HtmlAttributeName(DictionaryAttributePrefix = "page-url-")]
        public Dictionary<string, object> PageUrlValues { get; set; } = new Dictionary<string, object>();
        public bool PageClassesEnabled { get; set; } = false;
        public string PageClass { get; set; }
        public string PageClassNormal { get; set; }
        public string PageClassSelected { get; set; }


        //Overriding Methods
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(ViewContext);

            //build ul tag helper to hold page each page number
            TagBuilder result = new TagBuilder("div");

            //loop to build the pages i = page num
            for (int i = 1; i <= PageModel.TotalPages; i++)
            { 
                //build a tag 
                TagBuilder linkTag = new TagBuilder("a");

                PageUrlValues["page"] = i;
                //change the url
                linkTag.Attributes["href"] = urlHelper.Action(PageAction, PageUrlValues);


                //connect pages to classes
                if (PageClassesEnabled)
                {
                    linkTag.AddCssClass(PageClass);
                    linkTag.AddCssClass(i == PageModel.CurrentPage ? PageClassSelected : PageClassNormal);
                }
                
               
                linkTag.InnerHtml.AppendHtml(i.ToString());

                //add the a tags to the result var
                result.InnerHtml.AppendHtml(linkTag);
            }

            //output all of the tags
            output.Content.AppendHtml(result.InnerHtml);
        }

    }
}
