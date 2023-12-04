using System.ComponentModel.DataAnnotations;

namespace to_do_list.ViewModels;

public class RegisterViewModel
{   

    [Required(ErrorMessage = "Informe o Username")]
    public string Username { get; set; }
    
    [Required(ErrorMessage = "Informe o E-mail")]
    [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "O campo de Email nao e valido")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Informe o Senha")]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Compare("Password", ErrorMessage = "As senhas nao coincidem.")]
    [DataType(DataType.Password)]
    public string PasswordConfirmation { get; set; }

}