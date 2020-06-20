using WebApplication.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Models;

namespace WebApplication.TagHelpers
{
    /// <summary>
    /// userManager- upravljanje korisnicima, roleManager-upravljanje ulogama
    /// </summary>
    [HtmlTargetElement("td", Attributes = "i-role")]  
    
    public class RoleUsersTH : TagHelper
    {
        private UserManager<AppUser> userManager;
        private RoleManager<AppRole> roleManager;
  /// <summary>
  /// postavljanje opcija varijablama
  /// </summary>
  /// <param name="usermgr">varijabla sa opcijama upravljanja korisnicima</param>
  /// <param name="rolemgr">varijabla sa opcijama upravljanja ulogama</param>
        public RoleUsersTH(UserManager<AppUser> usermgr, RoleManager<AppRole> rolemgr)
        {
            userManager = usermgr;
            roleManager = rolemgr;
        }
  
        [HtmlAttributeName("i-role")]
        public string Role { get; set; }
  /// <summary>
  /// Analiza procesa
  /// </summary>
  /// <param name="context">sadržaj</param>
  /// <param name="output">izlazna vrijednost taga</param>
  /// <returns></returns>
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            List<string> names = new List<string>();
            AppRole role = await roleManager.FindByNameAsync(Role);
            if (role != null)
            {
                foreach (var user in userManager.Users)
                {
                    if (user != null && await userManager.IsInRoleAsync(user, role.Name))
                        names.Add(user.UserName);
                }
            }
            output.Content.SetContent(names.Count == 0 ? "No Users" : string.Join(", ", names));
        }
    }
}