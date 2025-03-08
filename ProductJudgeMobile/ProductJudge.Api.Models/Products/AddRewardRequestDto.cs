using System;

namespace ProductJudge.Api.Models.Products;

public class AddRewardRequestDto
{
    public string Reward { get; set; } = string.Empty;

    public string ProductId { get; set; } = string.Empty;

}
