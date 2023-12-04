using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using to_do_list.ViewModels;

namespace to_do_list.Controllers;

public class LoginController : Controller
{

    private readonly UserManager<IdentityUser> _userManager;

    public readonly SignInManager<IdentityUser> _signInManager;

    public LoginController(
        UserManager<IdentityUser> userManager,
        SignInManager<IdentityUser> signInManager
    )
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public IActionResult Sign()
    {
        var returnUrl = HttpContext.Request.Query["ReturnUrl"].ToString();
        return View(new LoginViewModel { ReturnUrl = returnUrl });
    }

    [HttpPost]
    public async Task<IActionResult> Sign(LoginViewModel model)
    {
        if (!ModelState.IsValid) 
            return View(model);

        var user = await _userManager.FindByEmailAsync(model.Email);

        if (user is null) 
        {
            TempData["Error"] = "Email ou senha invalidos";
            return View(model);
        }

        var authentication = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);

        if (authentication.Succeeded)
        {
            if (!string.IsNullOrEmpty(model.ReturnUrl))
                return Redirect(model.ReturnUrl);
            
            return RedirectToAction("Index", "TodoList");
            
        }

        return View(model);
    }
    public IActionResult Register() => View();

    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        if (!ModelState.IsValid) 
            return View(model);

        IdentityUser newUser = new() {
            UserName = model.Username,
            Email = model.Email
        };

        var result = await _userManager.CreateAsync(newUser, model.Password);

        if (result.Succeeded)
            return RedirectToAction("Sign");

        foreach(var error in result.Errors) 
        {
            ModelState.AddModelError(string.Empty, error.Description);
        }

        return View("Register", model);
    }


    public async Task<IActionResult> Logout()
    {
        if (_signInManager.IsSignedIn(User))
            await _signInManager.SignOutAsync();
        
        return RedirectToAction("Sign");
    }



}