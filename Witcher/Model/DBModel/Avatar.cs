using System;
using System.Collections.Generic;

namespace Witcher.Model.DBModel;

public partial class Avatar
{
    public int? CharacterId { get; set; }

    public string? PageImage { get; set; }

    public string? PreviewImage { get; set; }
}
