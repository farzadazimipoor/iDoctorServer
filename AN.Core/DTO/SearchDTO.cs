﻿using System.Collections.Generic;

namespace AN.Core.DTO
{
    public class SearchDTO
    {
        public string SearchTerm { get; set; }
    }

    public class SearchResultDTO
    {
        public List<SearchResulItemtDTO> Doctors { get; set; }
        public List<SearchResulItemtDTO> HealthTips { get; set; }
        public List<SearchResulItemtDTO> HealthBank { get; set; }
    }

    public class SearchResulItemtDTO
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Avatar { get; set; }
    }
}
