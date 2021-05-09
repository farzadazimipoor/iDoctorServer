﻿using AN.Core.Enums;

namespace AN.Core.DTO
{
    public class ServiceCategoryDTO : BaseDTO
    {
        public string Name { get; set; }
        public ShiftCenterType CenterType { get; set; }
    }

    public class ServiceDTO : BaseDTO
    {
        public string Name { get; set; }
        public int CategoryId { get; set; }
    }
}