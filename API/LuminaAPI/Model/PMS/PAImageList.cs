namespace LuminaAPI.Model.PMS
{
    public class PAImageList
    {

        public string ProductID { get; set; }

        public string Category { get; set; }

        public string Color { get; set; }

        public int CategoryID { get; set; }

        public int ColorID { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is PAImageList))
            {
                return false;
            }

            PAImageList other = (PAImageList)obj;

            return ProductID == other.ProductID &&
                   Category == other.Category &&
                   Color == other.Color &&
                   CategoryID == other.CategoryID &&
                   ColorID == other.ColorID;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ProductID, Category, Color, CategoryID, ColorID);
        }
    }
}
