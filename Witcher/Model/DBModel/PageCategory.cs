﻿using System;
using System.Collections.Generic;

namespace Witcher.Model.DBModel;

public partial class PageCategory
{
    public int? CharacterId { get; set; }

    public string? CategoryName { get; set; }

    public int? CategoryPriority { get; set; }
}
