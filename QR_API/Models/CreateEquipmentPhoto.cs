namespace QR_API.Models;

public class CreateEquipmentPhoto
{
    public long PhotoTableId { get; set; }

    public string? Photo { get; set; }

    public long EquipmentFkId { get; set; }
}