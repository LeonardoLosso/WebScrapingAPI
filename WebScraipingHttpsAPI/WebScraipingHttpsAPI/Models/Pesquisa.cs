namespace WebScraipingHttpsAPI.Models
{
    public static class Pesquisa
    {

        //remove os links de cabeçalho e rodapé 
        public static bool FiltrarPequisa(string item)
        {
            if (item.Contains("google") || item.Contains("search") || !item.Contains("https://"))
            {
                return false;
            }
            return true;
        }

        //quando tem um box do YT o link é duplicado
        public static bool VerificarLink(string url, List<Resultado> resultados)
        {
            foreach (var res in resultados)
            {
                if (res.Link.Equals(url))
                {
                    return false;
                }
            }
            return true;
        }

        /*public static string LimparLixo(string href)
        {
            int inicio, fim;
            inicio = href.IndexOf("https://www.");
            fim = href.IndexOf("&amp")-7;
            string https;

            //https = href.Substring(inicio, fim);

            return href;
        }*/
    }
}
