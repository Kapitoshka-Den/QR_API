using Microsoft.AspNetCore.Mvc;
using QR_API.Models;
using QR_API.Services;

namespace QR_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EquipmentController: ControllerBase
    {
        private QrServices _qrServices;

        public EquipmentController(QrServices qrServices)
        {
            _qrServices= qrServices;
        }

        [HttpPost]
        public async Task CreateEquipment(CreateEquipmentModel model)
            => await _qrServices.CreateEquipment(model);

        [HttpGet]
        public async Task<CreateEquipmentModel> GetEquipmentById(long id)
            => await _qrServices.GetEquipment(id);

        [HttpGet]
        public async Task<List<CreateEquipmentModel>> GetEquipments()
            => await _qrServices.GetEquipmetns();
    }
}
