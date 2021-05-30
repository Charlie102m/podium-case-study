namespace api.Controllers
{
    using System;
    using System.Threading.Tasks;
    using application.User;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    ///     A controller for authentication methods.
    /// </summary>
    public class AuthController : Controller
    {
        private readonly IUserManager _userManager;

        /// <summary>
        ///     Initializes a new instance of the <see cref="AuthController" /> class.
        /// </summary>
        /// <param name="userManager">The user manager.</param>
        public AuthController(IUserManager userManager)
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        }

        /// <summary>
        ///     An endpoint for registering a new user.
        /// </summary>
        /// <param name="userDto">The user to register.</param>
        /// <returns>The registered user.</returns>
        [HttpPost("[controller]/register")]
        public async Task<IActionResult> RegisterUser([FromBody] UserDto userDto)
        {
            var user = await _userManager.RegisterUserAsync(userDto, HttpContext.RequestAborted);

            // I would usually reference the location of the created resource
            // within the CreatedAtAction here, however as the get endpoint is
            // out of scope, I have just referenced the RegisterUser endpoint. 
            return CreatedAtAction(nameof(RegisterUser), user);
        }
    }
}