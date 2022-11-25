using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class EquipmentPhoto
{
    public long PhotoTableId { get; set; }

    public string? Photo { get; set; }

    public long EquipmentFkId { get; set; }

    public virtual Equipment EquipmentFk { get; set; } = null!;
}
