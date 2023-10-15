using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PERUSTARS.IdentityAndAccountManagement.Domain.Models;
using PERUSTARS.IdentityAndAccountManagement.Domain.Services;
using PERUSTARS.IdentityAndAccountManagement.Domain.Services.Communications;
using PERUSTARS.IdentityAndAccountManagement.Resources;
using Swashbuckle.AspNetCore.Annotations;

namespace PERUSTARS.IdentityAndAccountManagement.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UsersController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> AuthenticateAsync(AuthenticateRequest request)
        {
            var response = await _userService.Authenticate(request);
            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> RegisterAsync(RegisterRequest request)
        {
            await _userService.RegisterAsync(request);
            return Ok(new {message = "Registration successful"});
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var users = await _userService.ListAsync();
            var resources = _mapper.Map<IEnumerable<User>, IEnumerable<UserResource>>(users);
            return Ok(resources);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var user = await _userService.GetByIdAsync(id);
            var resource = _mapper.Map<User, UserResource>(user);
            return Ok(resource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, UpdateRequest request)
        {
            await _userService.UpdateAsync(id, request);
            return Ok(new {message = "User updated successfully."});
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _userService.DeleteAsync(id);
            return Ok(new {message = "User deleted successfully."});
        }
    }
}
