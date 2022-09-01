namespace Application._Configuration.Validation
{
    public class ValidatorMessage
    {
        public static string Obrigatorio(string campo) => $"Campo {campo} obrigatório.";

        public static string Entre(string campo, int minimo, int maximo) => $"Campo {campo} deve ter entre {minimo} e {maximo}.";

        public static string Invalido(string campo) => $"Campo {campo} inválido.";

        public static string NomeCompleto(string campo = "Nome") => $"Campo {campo} deve ser completo.";

        public static string Maximo(string campo, int maximo) => $"Campo {campo} deve ter no máximo {maximo} caracteres.";

        public static string MaiorQue(string campo, int value) => $"Campo {campo} deve ser maior que {value}.";

        public static string Minimo(string campo, int value) => $"Campo {campo} deve ter no mínimo {value} digitos.";
    }
}
