using Microsoft.AspNetCore.Mvc;
using TicketWave.Services;

[ApiController]
[Route("api/users")]
public class UserController : ControllerBase
{
    private readonly UserService _userService;

    public UserController(UserService userService)
    {
        _userService = userService;
    }

    // Register a new user
    [HttpPost("register")]
    public IActionResult Register([FromBody] RegisterUserDto request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = _userService.RegisterUser(request.UserName, request.Email, request.Password);
        
        if (!result)
            return BadRequest("User registration failed. Email or Username might already exist.");
        
        return Ok("User registered successfully.");
    }

    // User Login
    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginUserDto request)
    {
        var user = _userService.AuthenticateUser(request.Email, request.Password);
        
        if (user == null)
            return Unauthorized("Invalid email or password.");
        
        return Ok(new { message = "Login successful", user });
    }

    // Get user details
    [HttpGet("{id}")]
    public IActionResult GetUser(int id)
    {
        var user = _userService.GetUserById(id);
        
        if (user == null)
            return NotFound("User not found.");
        
        return Ok(user);
    }
}
