using AutoMapper;
using DAL.Context;
using Microsoft.AspNetCore.Components;
using QR_API.Models;
using DAL.Models;

namespace QR_API.Services
{
    public class QrServices
    {
        private readonly IMapper _mapper;
        private DataContext _context;

        public QrServices(IMapper mapper, DataContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateEquipment(CreateEquipmentModel createEquipment)
        {
            var equipment = _mapper.Map<CreateEquipmentModel, Equipment>(createEquipment);

            await _context.Equipments.AddAsync(equipment);
            await _context.SaveChangesAsync();
        }

        public async Task<CreateEquipmentModel> GetEquipment(long id)
        {
            var equipment = await _context.Equipments.FindAsync(id);
            if (equipment != null)
                return _mapper.Map<Equipment, CreateEquipmentModel>(equipment);
            else
                throw new Exception("user is not found");
        }
    }
}
