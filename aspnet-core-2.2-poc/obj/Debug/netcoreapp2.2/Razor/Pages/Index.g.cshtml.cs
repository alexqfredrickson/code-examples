#pragma checksum "/home/pompous/GitHub/code-examples/aspnet-core-2.2-poc/Pages/Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "61621deae174d44232e005f8ddbb33ec9a1c176f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(aspnetcoreapp.Pages.Pages_Index), @"mvc.1.0.razor-page", @"/Pages/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure.RazorPageAttribute(@"/Pages/Index.cshtml", typeof(aspnetcoreapp.Pages.Pages_Index), null)]
namespace aspnetcoreapp.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "/home/pompous/GitHub/code-examples/aspnet-core-2.2-poc/Pages/_ViewImports.cshtml"
using aspnetcoreapp;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"61621deae174d44232e005f8ddbb33ec9a1c176f", @"/Pages/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e70cdf4260bd324b075540e3ddbd00028c5e8dfc", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Index : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(26, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 4 "/home/pompous/GitHub/code-examples/aspnet-core-2.2-poc/Pages/Index.cshtml"
  
    ViewData["Title"] = "Address Book";

#line default
#line hidden
            BeginContext(76, 2024, true);
            WriteLiteral(@"
<article>
	<header>
		<p>Generic Blog Aggregation Website</p>
	</header>

	<div class=""articles"">
		test
	</div>
</article>

<div class=""modal"" tabindex=""-1"" role=""dialog"" id=""welcome-modal"">
  <div class=""modal-dialog"" role=""document"">
    <div class=""modal-content"">
      <div class=""modal-header"">
        <h5 class=""modal-title"">ASP.NET Core 2.2 POC</h5>
        <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
          <span aria-hidden=""true"">&times;</span>
        </button>
      </div>
      <div class=""modal-body"">
		<p>
			Welcome to my ASP.NET Core 2.2 proof-of-concept!  This is intended to be a simple CRUD application which functions like an address book.
		</p>

		<h1>
			Installation
		</h1>

		<div class=""alert alert-warning"" role=""alert"">
			<em>Note: the following instructions assume installation on a Linux Mint (or otherwise Ubuntu 18.04-compatible) environment.</em>
		</div>

		<ol>
			<li>
				Install the .NET Core 2.2.4 SDK:<b");
            WriteLiteral(@"r/>

				<code>
				wget -q https://packages.microsoft.com/config/ubuntu/18.04/packages-microsoft-prod.deb<br/>
				sudo dpkg -i packages-microsoft-prod.deb<br/>
				sudo add-apt-repository universe<br/>
				sudo apt-get install apt-transport-https<br/>
				sudo apt-get update<br/>
				sudo apt-get install dotnet-sdk-2.2<br/>
				</code>

				<div class=""alert alert-warning"" role=""alert"">
					<em>Note: <code>libicu60</code> may need to be manually installed as a workaround.</em>
				</div>
			</li>

			<li>
				Install Node package manager using <code>apt</code>, and <code>npm install</code> the project's dependencies.
			</li>
			
			<li>
				<code>cd</code> to the project directory and build/run the application using <code>dotnet run -v n</code> (the <code>-v n</code> argument will invoke normal verbosity - this provides some insight into the custom build procedures which compile *.less files).
			</li>
		</ol>
      </div>
    </div>
  </div>
</div>


");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IndexModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<IndexModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<IndexModel>)PageContext?.ViewData;
        public IndexModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
