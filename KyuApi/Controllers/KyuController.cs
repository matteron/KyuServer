using KyuApi.Business.Services.Main;
using KyuApi.Business.ViewModels.Requests;
using KyuApi.Controllers.Abstract;
using KyuApi.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KyuApi.Controllers
{
    public class KyuController : CustomController
    {
        private readonly IKyuService _kyuService;
        
        public KyuController(IKyuService kyuService) : base()
        {
            _kyuService = kyuService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_kyuService.GetEntries());
        }

        [HttpPost]
        public IActionResult CreateEntry([FromBody]EntryRequest request)
        {
            return Ok(_kyuService.CreateEntry(request));
        }
    }
}