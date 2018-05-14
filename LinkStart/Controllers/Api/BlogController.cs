using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using LinkStart.Core;
using LinkStart.Core.Dtos;
using LinkStart.Core.Models;
using Microsoft.AspNet.Identity;

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

/*
        [HttpGet]
        public async Task<IHttpActionResult> GetPost(int id)
        {
            var post = await _unitOfWork.PostRepository.GetSinglePost(id);

            if (post == null)
            {
                return BadRequest("Record Not Found");
            }

            var singlePost = Mapper.Map<Post, PostDto>(post);

            

            return Ok(singlePost);
        }*/

        [HttpGet]
        public async Task<IHttpActionResult> GetPosts()
        {
            var posts = await _unitOfWork.PostRepository.GetPostList();

            if (posts==null)
            {
                return BadRequest("Records not found");
            }

            var postDtoList = Mapper.Map<IEnumerable<Post>, IEnumerable<PostDto>>(posts);

            return Ok(postDtoList);
        }

        [HttpPost]
        public async Task<IHttpActionResult> AddPost([FromBody] PostDto postModelDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Please Fill in the required fields");
            }
            postModelDto.PosteDateTime = DateTime.Now;

            postModelDto.UserId = User.Identity.GetUserId();

            var post = Mapper.Map<PostDto,Post>(postModelDto);
            

            _unitOfWork.PostRepository.Add(post);
                
            await _unitOfWork.Complete();

            post = await _unitOfWork.PostRepository.GetSinglePost(post.Id);

            var postDto = Mapper.Map<Post, PostDto>(post);

            return Ok(postDto);
        }

        [HttpDelete]
        public async Task<IHttpActionResult> RemovePost(int id)
        {
            if (id ==0)
            {
                return BadRequest("invalid id");
            }

            var post = await _unitOfWork.PostRepository.GetSinglePost(id);

            _unitOfWork.PostRepository.Remove(post);

            await _unitOfWork.Complete();

            return Ok();
        }
    }
}
