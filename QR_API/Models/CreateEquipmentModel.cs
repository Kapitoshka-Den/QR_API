namespace QR_API.Models;

public class CreateEquipmentModel
{
    public long EquipmentTableId { get; set; }

    public string Title { get; set; } = null!;
    public string Avatar { get; set; } = null!;
    public string ResponsibleName { get; set; } = null!;

    public  ICollection<CreateEquipmentPhoto>? EquipmentPhotos { get; set; } = new List<CreateEquipmentPhoto>();
}