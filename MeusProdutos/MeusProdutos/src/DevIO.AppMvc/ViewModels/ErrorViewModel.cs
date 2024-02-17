namespace DevIO.AppMvc.ViewModels
{
    //Configuração de tratamento de erro personalizado está na web.config a partir da tag httpErrors
    public class ErrorViewModel
    {
        public int ErroCode { get; set; }
        public string Titulo { get; set; }
        public string Mensagem { get; set; }
    }
}