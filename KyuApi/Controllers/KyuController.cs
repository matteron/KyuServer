using System;
using KyuApi.Business.Services.Main;
using KyuApi.Business.ViewModels.Requests;
using KyuApi.Controllers.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KyuApi.Controllers
{
    [Authorize]
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

        [HttpPatch]
        public IActionResult UpdateEntry([FromBody]EntryRequest request)
        {
	        var result = _kyuService.UpdateEntry(request);
	        if (result == null)
	        {
		        return BadRequest("Entry not found.");
	        }
	        return Ok(result);
        }

        [HttpPatch("{direction}/{id:Guid}")]
        public IActionResult UpdateStatus(Guid id, string direction)
        {
            var result = _kyuService.UpdateStatus(id, direction);
            if (result == null) {
                return BadRequest("Entry not found.");
            }
            return Ok(result);
        }

        [HttpDelete("/{id:Guid}")]
        public IActionResult DeleteEntry(Guid id)
        {
            var result = _kyuService.Delete(id);
            if (result == null) {
                return BadRequest("Entry not found.");
            }
            return Ok(result);
        }
        
    }
}