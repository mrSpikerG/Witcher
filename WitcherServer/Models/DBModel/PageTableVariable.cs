using System;
using System.Collections.Generic;

namespace WitcherServer.Models.DBModel;

public partial class PageTableVariable
{
    public string? CategoryName { get; set; }

    public string? VariableName { get; set; }

    public string? VariableContext { get; set; }
}
