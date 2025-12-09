using System;
using System.Collections.Generic;

namespace BTLWEBAPI.Models;

public partial class KyNang
{
    public int MaKyNang { get; set; }

    public string TenKyNang { get; set; } = null!;

    public virtual ICollection<ViecLam> MaViecLams { get; set; } = new List<ViecLam>();
}
