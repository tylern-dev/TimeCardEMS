using System;

namespace TimeCard.Api.Core.Models {
  public class BaseModel {
    public DateTime CreatedDate { get; set; }
    public DateTime ModifiedDate { get; set; }
  }
}