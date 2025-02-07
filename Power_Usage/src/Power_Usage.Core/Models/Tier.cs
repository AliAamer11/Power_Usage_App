using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Power_Usage.Core.Models;

public class Tier
{
    public string Name { get; set; } = string.Empty;
    public int UpperLimmitInKwh { get; set; }
    public decimal Rate { get; set; }
}
