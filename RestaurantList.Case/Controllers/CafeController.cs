using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantList.Case.Entities;
using RestaurantList.Case.Entities.Dto;
using RestaurantList.Case.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantList.Case.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CafeController : ControllerBase
    {
        private readonly IGenericRepository<Cafe> _cafeRepository;
        private readonly IGenericRepository<Category> _categoryRepository;

        public CafeController(IGenericRepository<Cafe> cafeRepository, IGenericRepository<Category> categoryRepository)
        {
            _cafeRepository = cafeRepository;
            _categoryRepository = categoryRepository;
            
        }

        [HttpGet]
        [Route("GetListCafe")]
        public List<CafeResponseDto> GetListCafe()
        {
            var list = _cafeRepository.GetAll().Select(x=> new CafeResponseDto
            {
                CafeId = x.CafeId,
                CafeName = x.CafeName,
                CuisineType = x.CuisineType,
                Location = x.Location,
                CategoryId=x.CategoryId,
                CategoryName=x.Category?.Name
            }).ToList();
            return list;
        }

        [HttpGet]
        [Route("GetSingleCafe")]
        public CafeResponseDto GetSingleCafe(int id)
        {
            var result = _cafeRepository.GetAll().Where(x => x.CafeId == id).Select(x => new CafeResponseDto
            {
                CafeId = x.CafeId,
                CafeName = x.CafeName,
                CuisineType = x.CuisineType,
                Location = x.Location,
                CategoryName =x.Category?.Name,
                CategoryId = x.CategoryId
            }).SingleOrDefault();
            return result;
        }

        [HttpPut]
        [Route("UpdateCafe")]
        public CafeResponseDto UpdateCafe(CafeRequestDto model, int id)
        {
            var control = _cafeRepository.GetId(id);
            if (control != null)
            {
                control.CafeName = model.CafeName;
                control.Location = model.Location;
                control.CuisineType = model.CuisineType;
                control.Capacity = model.Capacity;
            }

           _cafeRepository.Update(control);

            var get = _cafeRepository.GetId(id);

            CafeResponseDto cafeResponseDto = new CafeResponseDto
            {
                CafeId = get.CafeId,
                CafeName = get.CafeName,
                CategoryId = get.CategoryId,
                CategoryName = get.Category.Name,
                CuisineType = get.CuisineType,
                Location = get.Location,


            };
            return cafeResponseDto;

        }




    }
}
