﻿using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Ecommerce.Catalog.Dtos.FeatureSliderDtos
{
    public class CreateFeatureSliderDto
    {
        public string Title { get; set; }
        public string Desciption { get; set; }
        public string ImageUrl { get; set; }
        public bool Status { get; set; }
    }
}
