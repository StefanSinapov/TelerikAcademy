namespace WcfRESTServiceDemo
{
    public class CategoryDTO
    {
        public int CategoryID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public static CategoryDTO CreateFromCategory(Category category)
        {
            CategoryDTO categoryDTO = new CategoryDTO();
            categoryDTO.CategoryID = category.CategoryID;
            categoryDTO.Name = category.CategoryName;
            categoryDTO.Description = category.Description;
            return categoryDTO;
        }
        
        public Category ToCategory()
        {
            Category category = new Category();
            category.CategoryID = this.CategoryID;
            category.CategoryName = this.Name;
            category.Description = this.Description;
            return category;
        }
    }
}
