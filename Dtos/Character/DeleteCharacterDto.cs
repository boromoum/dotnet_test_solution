using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMG.TestSolution.Api.Enums;

namespace CMG.TestSolution.Api.Dtos.Character
{
  public class DeleteCharacterDto
  {
    public int Id { get; set; }
    public string Name { get; set; } = "Borom";
    public int HitPoints { get; set; } = 100;
    public int Strength { get; set; } = 10;
    public int Defense { get; set; } = 10;
    public int Intell { get; set; } = 10;
    public RpgEnum RpgClass { get; set; } = RpgEnum.Knight;
  }
}