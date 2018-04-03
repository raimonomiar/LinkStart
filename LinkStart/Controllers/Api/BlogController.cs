using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using LinkStart.Core;
using LinkStart.Core.Dtos;
using LinkStart.Core.Models;

namespace LinkStart.Controllers.Api
{
    [Authorize]
    public class BlogController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public BlogController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        [HttpGet]
        public async Task<IHttpActionResult> GetPost(int id)
        {
            var post = await _unitOfWork.PostRepository.GetSinglePost(id);

            if (post == null)
            {
                return BadRequest("Record Not Found");
            }

            return Ok(post);
        }

        [HttpPost]
        public async Task<IHttpActionResult> AddPost([FromBody] PostDto postModelDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Please Fill in the required fields");
            }

            var post = Mapper.Map<PostDto, Post>(postModelDto);

            _unitOfWork.PostRepository.Add(post);

            await _unitOfWork.Complete();

            var id = _unitOfWork.PostRepository.GetId(post);

            return Ok(id);
        }
    }
}
