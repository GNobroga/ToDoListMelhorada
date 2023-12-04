using System.ComponentModel.DataAnnotations;

namespace to_do_list.ViewModels;

public class LoginViewModel 
{   
    [Required(ErrorMessage = "Informe o E-mail")]
    [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "O campo de Email nao e valido")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Informe o Senha")]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    public string ReturnUrl { get; set; } = string.Empty;
}