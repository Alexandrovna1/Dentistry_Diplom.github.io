using Dentistry_Diplom.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dentistry_Diplom.Infrastructure
{
    [HtmlTargetElement("div", Attributes = "page-model")]
    public class PageLinkTagHelper : TagHelper //это дескрипторный вспомогательный класс
    {
        private IUrlHelperFactory urlHelperFactory;
        public static int categoryId;
        public PageLinkTagHelper(IUrlHelperFactory factory)
        {
            urlHelperFactory = factory;
        }

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }
        public PagingInfo PageModel { get; set; }
        public string PageAction { get; set; }

        [HtmlAttributeName(DictionaryAttributePrefix = "page-url-")]
        public Dictionary<string, object> PageUrlValues { get; set; } = new Dictionary<string, object>();
        public bool PageClassesEnabled { get; set; } = false;
        public string Class { get; set; } //btn-group pull-right
        public string PageClass { get; set; } //btn
        public string PageClassNormal { get; set; } //btn-default
        public string PageClassSelected { get; set; }  //btn-primary

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(ViewContext); //интерфейс для работы с параметрами тэгов
            TagBuilder result = new TagBuilder("div"); //<div></div>

            for (int i = 1; i <= PageModel.TotalPages; i++)
            {
                TagBuilder aTag = new TagBuilder("a"); //<a></a>
                PageUrlValues["category"] = categoryId;
                PageUrlValues["page"] = i; // page = 1
                aTag.Attributes["href"] = urlHelper.Action(PageAction, PageUrlValues);//<a href="?category=1&page=1"></a>

                if (PageClassesEnabled)
                {
                    aTag.AddCssClass(PageClass); //<a class="btn"></a>
                    aTag.AddCssClass((i == PageModel.CurrentPage) ? PageClassSelected : PageClassNormal); //<a href="?page=1" class="btn btn-default"></a>
                }
                aTag.InnerHtml.Append(i.ToString());    //<a href="?page=1" class="btn btn-default">1</a>
                result.InnerHtml.AppendHtml(aTag);      //<div><a href="?page=1" class="btn btn-default">1</a></div>
            }
            output.Content.AppendHtml(result.InnerHtml);
        }
    }
}
