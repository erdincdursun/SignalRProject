using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.Business.Abstract;
using SignalR.DtoLayer.DiscountDto;
using SignalR.DtoLayer.FeatureDto;
using SignalR.EntityLayer.Entities;

namespace SignalR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturesController : ControllerBase
    {
        private readonly IFeatureService _featureService;
        private readonly IMapper _mapper;

        public FeaturesController(IFeatureService featureService, IMapper mapper)
        {
            _featureService = featureService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult FeatureList()
        {
            var values = _mapper.Map<List<ResultFeatureDto>>(_featureService.TGetAll());
            return Ok(values);

        }
        [HttpPost]
        public IActionResult CreateFeature(CreateFeatureDto createFeatureDto)
        {
            _featureService.TAdd(new Feature()
            {
                DescriptionFirst = createFeatureDto.DescriptionFirst,
                DescriptionThree = createFeatureDto.DescriptionThree,
                DescriptionTwo = createFeatureDto.DescriptionTwo,
                TitleFirst = createFeatureDto.TitleFirst,
                TitleTwo = createFeatureDto.TitleTwo,
                TitleThree = createFeatureDto.TitleThree

            });
            return Ok("Feature has been created successfully.");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteFeature(int id)
        {
            var value = _featureService.TGetById(id);
            _featureService.TDelete(value);
            return Ok("Feature has been deleted successfully.");
        }
        [HttpGet("{id}")]
        public IActionResult GetFeature(int id)
        {
            var value = _featureService.TGetById(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateFeature(UpdateFeatureDto updateFeatureDto)
        {
            _featureService.TUpdate(new Feature()
            {
                FeatureId = updateFeatureDto.FeatureId,
                DescriptionFirst = updateFeatureDto.DescriptionFirst,
                DescriptionThree = updateFeatureDto.DescriptionThree,
                DescriptionTwo = updateFeatureDto.DescriptionTwo,
                TitleFirst = updateFeatureDto.TitleFirst,
                TitleTwo = updateFeatureDto.TitleTwo,
                TitleThree = updateFeatureDto.TitleThree

            });
            return Ok("Feature has been updated successfully.");

        }

    }
}
