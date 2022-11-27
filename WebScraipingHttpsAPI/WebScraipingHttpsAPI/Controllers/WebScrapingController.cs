using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HtmlAgilityPack;
using WebScraipingHttpsAPI.Models;
using System.Linq;
using System.Text;
using System;
using System.Runtime.Serialization.Json;

namespace WebScraipingHttpsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WebScrapingController : ControllerBase
    {
        List<Resultado> resultados = new List<Resultado>();

        [HttpGet("search={pesquisa}")]
        public async Task<List<Resultado>> GetScrappResult(string pesquisa)
        {
            
            Encoding utf = Encoding.GetEncoding("utf-8");
            HtmlWeb web = new HtmlWeb()
            {
                AutoDetectEncoding = false,
                OverrideEncoding = utf,
            };
            HtmlDocument doc = web.Load($"https://www.google.com/search?q=" + pesquisa);


            var links = doc.DocumentNode.SelectNodes("//a");

            foreach (var link in links)
            {
                string titulo = link.Descendants().First().InnerText;
                string url = link.Attributes["href"].Value;

                if (Pesquisa.FiltrarPequisa(url) && Pesquisa.VerificarLink(url, resultados))
                {
                    resultados.Add(new Resultado(titulo, url));
                }
            }
            return resultados;
        }
    }
}
