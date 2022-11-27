using System.Security.Cryptography.X509Certificates;

namespace WebScraipingHttpsAPI.Models
{
    public class Resultado
    {
        public Resultado(string titulo, string link)
        {
            Titulo = titulo;
            Link = link;
        }

        public string Titulo { get; set; }
        public string Link { get; set; }
    }
}
