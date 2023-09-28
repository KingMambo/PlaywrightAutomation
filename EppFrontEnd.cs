using NUnit.Framework;
using System;
using Microsoft.Playwright;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static Microsoft.Playwright.Assertions;
using Microsoft.Playwright.NUnit;

namespace Application
{
	[TestFixture()]
	public class EppFrontEnd: PageTest
	{
		[Test]
		public async Task EppLoginPage()
		{
			//using var Page = await Playwright.CreateAsync();

			//launching a url on a specific browswer 
			//await playwright.Firefox.LaunchAsync(new()
			//{
			//Headless = false,
			//	SlowMo = 70,
			//});

			//var page = await browser.NewPageAsync();
			await Page.GotoAsync("https://keycloak-staging.app-stg.mukuru.io/realms/mukuru/protocol/openid-connect/auth?client_id=epp&scope=openid%20email%20profile&response_type=code&redirect_uri=https%3A%2F%2Fepp-frontend-staging.app-stg.mukuru.io%2Fapi%2Fauth%2Fcallback%2Fkeycloak&prompt=login&state=JifYahgyEIzrTTLRlpBGlijHkOkBb6g0_2HNnPX6fko&code_challenge=oHaNJKMcFkIscjiQr1G1OL5WQPva40QLYwtwFI6TKX0&code_challenge_method=S256");

            //3 second wait before clicking the login button on the home page
            Thread.Sleep(3000);

			await Page.GetByPlaceholder("Enter Email").FillAsync("briank+1@mukuru.com");
			await Page.GetByLabel("Password").FillAsync("Password@21");
            await Page.GetByLabel("Remember me").CheckAsync();

            Thread.Sleep(3000);
            await Page.GetByRole(AriaRole.Button, new() { NameRegex = new Regex("login", RegexOptions.IgnoreCase)}).ClickAsync();
           
            //try clearing the cache before hitting the second button.
            
            await Page.GetByRole(AriaRole.Button, new() { NameRegex = new Regex("sign in with keycloak", RegexOptions.IgnoreCase) }).ClickAsync();

            Thread.Sleep(3000);// 3 second delay after hitting the sign in with keycloak button.


			//TO DO
			/*Before checking if the page has a specific component we need to ascertian if it the element is visible in the first place,
			 * for this we need to employ assertions that run visibility checks the page's tabs, headings etc.
			 */
			await Expect(Page).ToHaveTitleAsync(new Regex("Epp Frontend", RegexOptions.IgnoreCase)); //checking if the main page has the Epp Title

			Thread.Sleep(5000);
            //taking a screenshot of the page
            await Page.ScreenshotAsync(new PageScreenshotOptions
            {   
				Path = "LoginScreenshot.png", FullPage=true
			}) ;

			Thread.Sleep(3000);
        }	 
	}
}

