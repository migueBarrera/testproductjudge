﻿namespace ProductJudge.Api.Models.Products;

public class GetProductByResponseDto

{
    public string Id { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string CategoryId { get; set; } = string.Empty;
}
