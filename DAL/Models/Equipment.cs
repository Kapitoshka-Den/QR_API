using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Equipment
{
    public long EquipmentTableId { get; set; }

    public string Title { get; set; } = null!;
    public string Avatar { get; set; } = null!;
    public string? ResponsibleName { get; set; }

    public virtual ICollection<EquipmentPhoto> EquipmentPhotos { get; } = new List<EquipmentPhoto>();
}
