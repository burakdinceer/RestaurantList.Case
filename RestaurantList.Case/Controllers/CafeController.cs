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
            }).SingleOrDefault();
            return result;
        }


    }
}
