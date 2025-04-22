using System;
using System.Collections.Generic;

namespace BusinessNewsApp.Models
{
    public class NewsApiResponse
    {
        public List<Article> Articles { get; set; }
    }

    public class Article
    {
        public Source Source { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
    }

    public class Source
    {
        public string Name { get; set; }
    }
}

