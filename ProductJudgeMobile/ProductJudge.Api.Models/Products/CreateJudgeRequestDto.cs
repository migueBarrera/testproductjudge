using System;

namespace ProductJudge.Api.Models.Products;

public class CreateJudgeRequestDto
{
    public string Judge { get; set; } = string.Empty;

    public string ProductId { get; set; } = string.Empty;
    
    public string UserId { get; set; } = string.Empty;

}
