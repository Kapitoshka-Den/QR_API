using AutoMapper;
using DAL.Models;
using QR_API.Models;

namespace QR_API;

public class MapperProfile:Profile
{
    public MapperProfile()
    {
        CreateMap<CreateEquipmentModel, Equipment>();
        CreateMap<Equipment, CreateEquipmentModel>();
        CreateMap<EquipmentPhoto, CreateEquipmentPhoto>();
    }
}