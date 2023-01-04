namespace GeekShopping.Web.Models
{
    public class ProductModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; }
        public string ImageUrl { get; set; }

        public string SubstringName
        {
            get
            {
                if (Name.Length > 24)
                {
                    return Name.Substring(0, 20) + "...";
                }
                return Name;
            }
        }

        public string SubstringDescription
        {
          get
          {
            if (Description.Length > 355)
            {
              return Description.Substring(0, 352) + "...";
            }
            return Description;
          }
        }
  }
}
