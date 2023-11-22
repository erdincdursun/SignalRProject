using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.Business.Abstract;
using SignalR.DtoLayer.ProductDto;
using SignalR.DtoLayer.SocialMediaDto;
using SignalR.EntityLayer.Entities;

namespace SignalR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediasController : ControllerBase
    {
        private readonly ISocialMediaService _socialMediaService;
        private readonly IMapper _mapper;

        public SocialMediasController(ISocialMediaService socialMediaService, IMapper mapper)
        {
            _socialMediaService = socialMediaService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult SocialMediaList()
        {
            var values = _mapper.Map<List<ResultSocialMediaDto>>(_socialMediaService.TGetAll());
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreatedSocialMedia(CreateSocialMediaDto createSocialMediaDto)
        {
            _socialMediaService.TAdd(new SocialMedia()
            {
               Icon = createSocialMediaDto.Icon,
               Title = createSocialMediaDto.Title,
               Url = createSocialMediaDto.Url
            });
            return Ok("Social Media has been added successfully.");
        }
        [HttpDelete]
        public IActionResult DeleteSocialMedia(int id)
        {
            var value = _socialMediaService.TGetById(id);
            _socialMediaService.TDelete(value);
            return Ok("Social Media has been deleted successfully.");
        }

        [HttpGet("GetSocialMedia")]
        public IActionResult GetSocialMedia(int id)
        {
            var value = _mapper.Map<GetSocialMediaDto>(_socialMediaService.TGetById(id));
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateSocialMedia(UpdateSocialMediaDto updateSocialMediaDto)
        {


            _socialMediaService.TUpdate(new SocialMedia()
            {
                Icon = updateSocialMediaDto.Icon,
                Title = updateSocialMediaDto.Title,
                Url = updateSocialMediaDto.Url,
                SocialMediaId = updateSocialMediaDto.SocialMediaId

            });
            return Ok("Social Media has been updated successfully.");
        }
    }
}
