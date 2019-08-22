using TimeCard.Api.Core.Interfaces;

namespace TimeCard.Api.Core.Models {
  public class IdKeyModel : BaseModel, IIdKeyModel
  {
    public int Id { get; set; }
  }
}