using System;
using System.Collections.Generic;
using WebApplication.ViewModels;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.Extensions.Options;

namespace WebApplication.TagHelpers
{
    [HtmlTargetElement(Attributes = "page-info")]
    public class PagerTagHelper : TagHelper
    ///javna klasa PagerTagHelper 
    {
        private readonly AppSettings _appSettings;
        private readonly IUrlHelperFactory _urlHelperFactory;
        /// <summary>
        /// Dodjeljivanje vrijednosti za _urlHelperFactory i _appSettings
        /// </summary>
        /// <param name="helperFactory"> pomoćna varijabla</param>
        /// <param name="optionsSnapshot">opcijski snapshot</param>

        public PagerTagHelper(IUrlHelperFactory helperFactory, IOptionsSnapshot<AppSettings> optionsSnapshot)
        
        {
            
            this._urlHelperFactory = helperFactory;
            _appSettings = optionsSnapshot.Value;
        }
        /// <summary>
        /// ViewContext je sadržaj stranice, PageInfo označava izbornike,PageTitle-naslov stranice,PageAction-akcije koje je moguće izvršiti na stranici
        /// </summary>
        
        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }
        public PagingInfo PageInfo { get; set; }
        public string PageTitle { get; set; }
        public string PageAction { get; set; }
        
/// <summary>
/// Prilagođavanje veličine
/// </summary>
/// <param name="context">Tag sadržaj</param>
/// <param name="output">Vrijednost izlaza taga</param>
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "nav";
            int offset = _appSettings.PageOffset;
            TagBuilder paginationList = new TagBuilder("ul");
            paginationList.AddCssClass("pagination");
            
            if (PageInfo.CurrentPage - offset > 1)
            {
                var tag = BuildListItemForPage(1, "1..");
                paginationList.InnerHtml.AppendHtml(tag);
            }

            for (int i = Math.Max(1, PageInfo.CurrentPage - offset); i <= Math.Min(PageInfo.TotalPages, PageInfo.CurrentPage + offset); i++)
            {
                var tag = i == PageInfo.CurrentPage ? BuildListItemForCurrentPage(i) : BuildListItemForPage(i);
                paginationList.InnerHtml.AppendHtml(tag);
            }
            
            if (PageInfo.CurrentPage + offset < PageInfo.TotalPages)
            {
                var tag = BuildListItemForPage(PageInfo.TotalPages, ".." + PageInfo.TotalPages);
                paginationList.InnerHtml.AppendHtml(tag);
            }

            output.Content.AppendHtml(paginationList);
        }/// <summary>
         /// Popunjavanje atributa
         /// </summary>
         /// <param name="i"> neki cijeli broj</param>
         /// <returns>li</returns>

        private TagBuilder BuildListItemForCurrentPage(int i)
        {
            IUrlHelper urlHelper = _urlHelperFactory.GetUrlHelper(ViewContext);
            TagBuilder input = new TagBuilder("input");
            input.Attributes["type"] = "text";
            input.Attributes["value"] = i.ToString();
            input.Attributes["data-current"] = i.ToString();
            input.Attributes["data-min"] = "1";
            input.Attributes["data-max"] = PageInfo.TotalPages.ToString();
            input.Attributes["data-url"] = urlHelper.Action(PageAction, new
            {
                page = -1,
                sort = PageInfo.Sort,
                ascending = PageInfo.Ascending
            });
            input.AddCssClass("page-link");
            input.AddCssClass("pagebox");
            if (!string.IsNullOrWhiteSpace(PageTitle))
            {
                input.Attributes["title"] = PageTitle;
            }
            TagBuilder li = new TagBuilder("li");
            li.AddCssClass("page-item active");
            li.InnerHtml.AppendHtml(input);
            return li;
        }
/// <summary>
/// Privatna funkcija za kreiranje tagova
/// </summary>
/// <param name="i">cijeli broj</param>
/// <returns>poziva funkciju BuildListItemForPage</returns>
        private TagBuilder BuildListItemForPage(int i)
        {
            return BuildListItemForPage(i, i.ToString());
        }
/// <summary>
/// Kreira listu predmeta za neku stranicu koja je određena brojem u varijabli i
/// </summary>
/// <param name="i">označava stranicu</param>
/// <param name="text">string koji dodajemo na kraj naziva taga</param>
/// <returns>li</returns>
        private TagBuilder BuildListItemForPage(int i, string text)
        {
            IUrlHelper urlHelper = _urlHelperFactory.GetUrlHelper(ViewContext);
            TagBuilder a = new TagBuilder("a");
            a.InnerHtml.Append(text);
            a.Attributes["href"] = urlHelper.Action(PageAction, new
            {
                page = i,
                sort = PageInfo.Sort,
                ascending = PageInfo.Ascending
            });
            a.AddCssClass("page-link");
            TagBuilder li = new TagBuilder("li");
            li.AddCssClass("page-item");
            li.InnerHtml.AppendHtml(a);
            return li;
        }

    }
}