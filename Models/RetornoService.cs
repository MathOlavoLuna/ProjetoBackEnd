using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace API_VidaPlus.Models
{
    public class RetornoService<T>
    {
        public bool  Sucesso {  get; set; } = false;
        public T? Data { get; set; }
        public string Erro {  get; set; } = string.Empty;
        public RetornoService(bool success,T data, string erro)
        {
            Sucesso = success;  
            Data = data;
            Erro = erro;
        }

    }
}
