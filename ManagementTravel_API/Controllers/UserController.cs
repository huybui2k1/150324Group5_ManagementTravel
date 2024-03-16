using AutoMapper;
using Catel.Data;
using ManagementTravel_API.BusinessObjects;
using ManagementTravel_API.BusinessObjects.Domain;
using ManagementTravel_API.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Drawing.Drawing2D;
using System.Drawing;
using ManagementTravel_API.BusinessObjects.DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ManagementTravel_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ManagementTravelDBContext dbContext;
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;
        private readonly ILogger<UserController> logger;
        // GET: api/<UserController>
        public UserController(ManagementTravelDBContext dbContext,
            IUserRepository userRepository,
            IMapper mapper,
            ILogger<UserController> logger)
        {
            this.dbContext = dbContext;
            this.userRepository = userRepository;
            this.mapper = mapper;
            this.logger = logger;
        }

        // GET ALL userS
        // GET: https://localhost:portnumber/api/users
        [HttpGet]
        //[Authorize(Roles = "Reader")]
        public async Task<IActionResult> GetAll()
        {
            // Get Data From Database - Domain models
            var usersDomain = await userRepository.GetAllAsync();

            // Return DTOs
            return Ok(mapper.Map<List<UserDto>>(usersDomain));
        }


        // GET SINGLE user (Get user By ID)
        // GET: https://localhost:portnumber/api/users/{id}
        [HttpGet]
        [Route("{id:Guid}")]
        //[Authorize(Roles = "Reader")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            //var user = dbContext.users.Find(id);
            // Get user Domain Model From Database
            var userDomain = await userRepository.GetByIdAsync(id);

            if (userDomain == null)
            {
                return NotFound();
            }

            // Return DTO back to client
            return Ok(mapper.Map<UserDto>(userDomain));
        }


        // POST To Create New user
        // POST: https://localhost:portnumber/api/users
        [HttpPost]
        /*[ValidateModel]*/
        //[Authorize(Roles = "Writer")]
        public async Task<IActionResult> Create([FromBody] AddUserRequestDto adduserRequestDto)
        {
            // Map or Convert DTO to Domain Model
            var userDomainModel = mapper.Map<User>(adduserRequestDto);

            // Use Domain Model to create user
            userDomainModel = await userRepository.CreateAsync(userDomainModel);

            // Map Domain model back to DTO
            var UserDto = mapper.Map<UserDto>(userDomainModel);

            return CreatedAtAction(nameof(GetById), new { id = UserDto.UserId }, UserDto);
        }


        // Update user
        // PUT: https://localhost:portnumber/api/users/{id}
        [HttpPut]
        [Route("{id:Guid}")]
        /*[ValidateModel]*/
        //[Authorize(Roles = "Writer")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateUserRequestDto updateuserRequestDto)
        {

            // Map DTO to Domain Model
            var userDomainModel = mapper.Map<User>(updateuserRequestDto);

            // Check if user exists
            userDomainModel = await userRepository.UpdateAsync(id, userDomainModel);

            if (userDomainModel == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<UserDto>(userDomainModel));
        }


        // Delete user
        // DELETE: https://localhost:portnumber/api/users/{id}
        [HttpDelete]
        [Route("{id:Guid}")]
        //[Authorize(Roles = "Writer,Reader")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var userDomainModel = await userRepository.DeleteAsync(id);

            if (userDomainModel == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<UserDto>(userDomainModel));
        }
    }
    }

