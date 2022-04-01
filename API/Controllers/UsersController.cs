using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;

namespace API.Controllers
{
    [Authorize]
 
    public class UsersController : BaseApiController
    {
      

        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UsersController(IUserRepository userRepository, IMapper mapper)
        {
         
            _mapper = mapper;
            _userRepository = userRepository;
        }

        [HttpGet]
        // [AllowAnonymous]
      public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers()
        {
            var users = await _userRepository.GetMembersAsync();

            return Ok(users);
        }


        //1 [Authorize]
        // api/users/1,2,3
      [HttpGet("{username}")]
        public async Task<ActionResult<MemberDto>> GetUser(string username)
        {
            
            return await _userRepository.GetMemberAsync(username);
        }


    }
}